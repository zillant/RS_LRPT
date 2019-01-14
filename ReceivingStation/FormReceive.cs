using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ReceivingStation.Other;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using MaterialSkin.Controls;
using ReceivingStation.MessageBoxes;
using ReceivingStation.Properties;

namespace ReceivingStation
{
    public partial class FormReceive : MaterialForm
    {       
        public static TimeSpan MainFcpWorkingTime;
        public static TimeSpan ReserveFcpWorkingTime;
        public static TimeSpan MainPrdWorkingTime;
        public static TimeSpan ReservePrdWorkingTime;
        public static TimeSpan FullWorkingTime; // Общее время работы системы. (Не используем в релизе)        
        
        private const int TimeForSaveWorkingTime = 1800; // Время для таймера (сек), через которое нужно сохранять наработку в файл. 
        private int _counterForSaveWorkingTime; // Счетчик для таймера, через которое нужно сохранять время наработки в файл.
        
        private string _fileName;
        private bool _isReceivingStarting;
        private bool _isModulationPanelVisible; // Для скрытия панели модуляции.

        private int _callingUpdateImageCounter; // Сколько раз был вызван метод UpdateGui. Нужно для сохранения изображений на диск.
        private long _imageCounter; // Счетчик сохранненых изображений.

        private Panel[] _allChannelsPanels = new Panel[6]; // Панели на которых находятся FLP для всех каналов.
        private Panel[] _channelsPanels = new Panel[6]; // Панели на которых находятся FLP для каждого канала.
        private FlowLayoutPanel[] _channels = new FlowLayoutPanel[6]; // FLP для хранения полосок изображения для каждого канала.
        private FlowLayoutPanel[] _allChannels = new FlowLayoutPanel[6]; // FLP для хранения полосок изображения для всех каналов.
        private List<Bitmap>[] _listImagesForSave = new List<Bitmap>[6]; // Список для хранения полосок изображения, нужно для сохранения.

        private DateTime _startWorkingTime; // Время начала работы борта.

        private Demodulator.Demodulating _receiver;
        private Server.Server _server;
        private Thread _serverThread;
        private Decode.Decode _decode;

        // Параметры приема битового потока.
        private byte _fcp;
        private byte _prd;
        private byte _freq;
        private byte _interliving;
        private byte _modulation;

        private bool[] flags = new bool[2]; // массив состояний демодулятора flag[0] = синхронизация фазы синхропосылки; flag[1] = захват петли ФАПЧ

        public FormReceive()
        {
            InitializeComponent();
        }

        private void FormReceive_Load(object sender, EventArgs e)
        {
            lblDemOn.Text = "";
            lblDongOn.Text = "";
            lblLockOn.Text = "";
            lblSignDetect.Text = "";

            GuiUpdater.SmoothLoadingForm(this);

            GuiUpdater.DecodeRichTextBoxInit(rtbMkoTitle, rtbMkoData, rtbDateTimeTitle, rtbDateTime);

            materialTabControl1.SelectedTab = tabPage7;

            Server.Server.RemoteModeFlag = false;
            _isReceivingStarting = false;
            _counterForSaveWorkingTime = TimeForSaveWorkingTime;
            _isModulationPanelVisible = false;

            OpenLogWorkingTimeFile();

            _channelsPanels[0] = pImage1;
            _channelsPanels[1] = pImage2;
            _channelsPanels[2] = pImage3;
            _channelsPanels[3] = pImage4;
            _channelsPanels[4] = pImage5;
            _channelsPanels[5] = pImage6;

            _allChannelsPanels[0] = pImage7;
            _allChannelsPanels[1] = pImage8;
            _allChannelsPanels[2] = pImage9;
            _allChannelsPanels[3] = pImage10;
            _allChannelsPanels[4] = pImage11;
            _allChannelsPanels[5] = pImage12;

            for (int i = 0; i < 6; i++)
            {
                _allChannels[i] = GuiUpdater.GetFlp(new Size(242, 8));
                _channels[i] = GuiUpdater.GetFlp(new Size(1556, 40));
                _allChannelsPanels[i].Controls.Add(_allChannels[i]);
                _channelsPanels[i].Controls.Add(_channels[i]);
                _listImagesForSave[i] = new List<Bitmap>();
            }

            slTime.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            timer1.Start();

            _server = new Server.Server(false)
            {
                ThreadSafeChangeMode = ChangeMode,
                ThreadSafeSetReceiveParameters = SetReceiveParameters,
                ThreadSafeStartStopReceiving = StartStopReceiving,
            };

            _serverThread = new Thread(_server.StartServer) {IsBackground = true};
            _serverThread.Start();
        }

        private void FormReceive_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = FormDialogMessageBox.Show("Выход", "Вы уверены, что хотите закрыть программу?", Resources.door_exit_icon);

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void FormReceive_FormClosed(object sender, FormClosedEventArgs e)
        {
            _server.StopThread = true;
            _serverThread.Join(100);

            Application.Exit();
        }

        private void FormReceive_KeyDown(object sender, KeyEventArgs e)
        {
            // Alt + L  
            if (e.Alt && e.KeyCode == Keys.L)
            {
                if (!_isModulationPanelVisible)
                {
                    pModulation.Visible = true;
                    _isModulationPanelVisible = true;
                }
                else
                {
                    pModulation.Visible = false;
                    _isModulationPanelVisible = false;
                }
                e.SuppressKeyPress = true;
            }
        }

        private void btnStartRecieve_Click(object sender, EventArgs e)
        {           
            StartStopReceiving();
        }

        private void slMode_DoubleClick(object sender, EventArgs e)
        {
            using (FormModeSettings modeSettingsForm = new FormModeSettings())
            {
                modeSettingsForm.ChangeMode = ChangeMode;
                modeSettingsForm.ShowDialog();
            }
        }

        private void slWorkingTimeOnboard_DoubleClick(object sender, EventArgs e)
        {
            using (FormWorkingTimes workingTimesForm = new FormWorkingTimes())
            {
                workingTimesForm.ShowDialog();
            }
        }

        private void slMode_MouseLeave(object sender, EventArgs e)
        {
            slMode.BackColor = SystemColors.Window;
        }

        private void slWorkingTimeOnboard_MouseLeave(object sender, EventArgs e)
        {
            slWorkingTimeOnboard.BackColor = SystemColors.Window;
        }

        private void slWorkingTimeOnboard_MouseMove(object sender, MouseEventArgs e)
        {
            slWorkingTimeOnboard.BackColor = SystemColors.ControlLight;
        }

        private void slMode_MouseMove(object sender, MouseEventArgs e)
        {
            slMode.BackColor = SystemColors.ControlLight;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            slTime.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);

            _counterForSaveWorkingTime -= 1;

            if (_counterForSaveWorkingTime == 0)
            {
                if (_isReceivingStarting)
                {
                    CountWorkingTime();
                    _startWorkingTime = DateTime.Now;
                    WriteToLogWorkingTime(ApplicationDirectory.WorkingTimeOnBoardFile);
                }
                _counterForSaveWorkingTime = TimeForSaveWorkingTime;

            }
            
            if (_isReceivingStarting)
            {
                flags = _receiver.UpdateDataGui();
                UpdateGuiDemodulationData(flags);
            }

        }

        private void bwImageSaver_DoWork(object sender, DoWorkEventArgs e)
        {
            ImageSaver.SaveImage(_listImagesForSave, _fileName, _imageCounter);
            _imageCounter += 1;
        }

        #region Начать прием потока.
        public void StartStopReceiving()
        {
            if (!_isReceivingStarting)
            {               

                if (!Server.Server.RemoteModeFlag)
                {
                    SetReceiveParameters();
                }

                _isReceivingStarting = true;

                btnStartRecieve.SetPropertyThreadSafe(() => btnStartRecieve.Text, "Остановить");
                tlpReceivingParameters.SetPropertyThreadSafe(() => tlpReceivingParameters.Enabled, false);

                string fcps = "";
                string prds = "";
                string inters = "";
                string freqs = "";

                if (_fcp == 0x1) fcps = "O";
                else if (_fcp == 0x2) fcps = "P";

                if (_prd == 0x1) prds = "O";
                else if (_prd == 0x2) prds = "P";

                if (_freq == 0x1) freqs = "137.1";
                else if (_freq == 0x2) freqs = "137.9";

                if (_interliving == 0x1) inters = "с_инт";
                else if (_interliving == 0x2) inters = "без_инт";


                var timeString = DateTime.Now.ToString("HH-mm-ss");
                var sessionName = $"{timeString}_{fcps}_{prds}_{freqs}_{inters}";

                _fileName = $"{ApplicationDirectory.GetCurrentSessionDirectory($"{sessionName}")}\\{sessionName}";

                _decode = new Decode.Decode(_fileName) { ThreadSafeUpdateGui = UpdateGuiDecodeData };

            
                // Очистка всего перед новым запуском.
                for (int i = 0; i < 6; i++)
                {
                    _allChannels[i].Controls.Clear();
                    _channels[i].Controls.Clear();
                    _listImagesForSave[i].Clear();
                    Directory.CreateDirectory($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileName(_fileName)}_Channel_{i + 1}");
                    DirectoryInfo di = new DirectoryInfo($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileName(_fileName)}_Channel_{i + 1}");

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                }

                _startWorkingTime = DateTime.Now;
                _imageCounter = 0;
                _callingUpdateImageCounter = 0;               

                UserLog.WriteToLogUserActions($"Установлены параметры: ФПЦ - {_fcp}, ПРД - {_prd}, Частота - {_freq}, Интерливинг - {_interliving}");
                UserLog.WriteToLogUserActions("Запись потока начата");

                if (rbOqpsk.Checked) _modulation = 0x2;
                if (rbQpsk.Checked) _modulation = 0x1;

                _receiver = new Demodulator.Demodulating(this, _fileName, _freq, _interliving, _modulation, _decode);
                _receiver.Dongle_Configuration(1024000);// инициализируем свисток, в нем отсчеты записываются в поток
                _receiver.StartDecoding();
                _receiver.RecordStart();

                lblDemOn.SetPropertyThreadSafe(() => lblDemOn.Text, "Демодулятор включен");
                lblDongOn.SetPropertyThreadSafe(() => lblDongOn.Text, "Приемник включен");
            }
            else
            {
                 StopReceiving();
            }

        }
      
        #endregion

        #region Остановить прием потока.
        public void StopReceiving()
        {
            _isReceivingStarting = false;

            btnStartRecieve.SetPropertyThreadSafe(() => btnStartRecieve.Text, "Начать");
            lblDemOn.SetPropertyThreadSafe(() => lblDemOn.Text, "Демодулятор выключен");
            lblDongOn.SetPropertyThreadSafe(() => lblDongOn.Text, "Приемник выключен");
            lblLockOn.SetPropertyThreadSafe(() => lblLockOn.Text, "");
            lblSignDetect.SetPropertyThreadSafe(() => lblSignDetect.Text, "");

            tlpReceivingParameters.SetPropertyThreadSafe(() => tlpReceivingParameters.Enabled, true);

            _receiver.StopDecoding();
            _decode.FinishDecode();

            CountWorkingTime();
            WriteToLogWorkingTime(ApplicationDirectory.WorkingTimeOnBoardFile);

            UserLog.WriteToLogUserActions("Запись потока завершена");

            FormInformationMessageBox.Show("Сообщение", "Прием потока завершен.", Resources.done_icon, "Перейти в", "каталог с результатами", _fileName);
        }

        #endregion

        #region Смена режима управления.
        private void ChangeMode(byte modeNumber)
        {
            if (modeNumber == 0)
            {              
                // Дистанционное управление
                tlp1.SetPropertyThreadSafe(() => tlp1.Enabled, false);
                Invoke(new Action(() => { slMode.Text = Resources.RemoteControlString; }));

                UserLog.WriteToLogUserActions(Resources.RemoteControlString);


            }
            else if (modeNumber == 1)
            {
                // Местное управление
                tlp1.SetPropertyThreadSafe(() => tlp1.Enabled, true);
                Invoke(new Action(() => { slMode.Text = Resources.LocalControlString; }));

                UserLog.WriteToLogUserActions(Resources.LocalControlString);
            }
        }

        #endregion

        #region Установка параметров записи потока в дистанционном режиме управления.
        private void SetReceiveParameters(byte fcp, byte prd, byte freq, byte interliving)
        {
            _fcp = fcp;
            _prd = prd;
            _freq = freq;
            _interliving = interliving;

            Invoke(new Action(() => { SetRadioButtons(_fcp, rbFCPMain, rbFCPReserve); }));
            Invoke(new Action(() => { SetRadioButtons(_prd, rbPRDMain, rbPRDReserve); }));
            Invoke(new Action(() => {SetRadioButtons(_freq, rbFreq1, rbFreq2); }));
            Invoke(new Action(() => {SetRadioButtons(_interliving, rbInterlivingReceiveOn, rbInterlivingReceiveOff); }));
        }

        private void SetRadioButtons(byte param, RadioButton rb1, RadioButton rb2)
        {
            if (param == 0x1)
            {
                rb1.Checked = true;
            }
            else
            {
                rb2.Checked = true;
            }
        }
        
        #endregion

        #region Установка параметров записи потока в местном режиме управления.
        private void SetReceiveParameters()
        {
            _fcp = Convert.ToByte(rbFCPMain.Checked ? 0x1 : 0x2);
            _prd = Convert.ToByte(rbPRDMain.Checked ? 0x1 : 0x2);
            _freq = Convert.ToByte(rbFreq1.Checked ? 0x1 : 0x2);
            _interliving = Convert.ToByte(rbInterlivingReceiveOn.Checked ? 0x1 : 0x2);
        }

        #endregion

        #region Обновление данных декодирования на GUI.
        private void UpdateGuiDecodeData(DateTime linesDate, string linesTd, string linesOshv, string linesBshv, string linesPcdm, DirectBitmap[] imagesLines)
        {
            _callingUpdateImageCounter++;

            // Набрал 480 строчек изображения (8 * 60).
            if (_callingUpdateImageCounter == 60)
            {
                bwImageSaver.RunWorkerAsync();
                _callingUpdateImageCounter = 0;
            }

            if (InvokeRequired)
            {
                Invoke(new Action(() => GuiUpdater.UpdateGuiDecodeData(linesTd, linesOshv, linesBshv, linesPcdm, linesDate,
                    rtbDateTime, rtbMkoData, _channels, _allChannels, _channelsPanels, _allChannelsPanels, _listImagesForSave, imagesLines)));
            }
        }
        #endregion

        #region Обновление данных демодуляции на GUI.
        private void UpdateGuiDemodulationData(bool[] flags)
        {
            if (flags[1]) lblLockOn.SetPropertyThreadSafe(() => lblLockOn.Text, "Захвачено");
            else
            {
                lblLockOn.SetPropertyThreadSafe(() => lblLockOn.Text, "Захват...");
                lblSignDetect.SetPropertyThreadSafe(() => lblSignDetect.Text, "");
            }
            if (flags[0] && flags[1]) lblSignDetect.SetPropertyThreadSafe(() => lblSignDetect.Text, "Синхромаркер найден");
            else if (!flags[0] && flags[1]) lblSignDetect.SetPropertyThreadSafe(() => lblSignDetect.Text, "Поиск синхромаркера...");
        }

        #endregion

        #region Расчет времени наработки.
        private void CountWorkingTime()
        {
            DateTime finishWorkingTime = DateTime.Now;
            TimeSpan deltaWorkingTime = finishWorkingTime - _startWorkingTime;
            FullWorkingTime += deltaWorkingTime;

            if (rbFCPMain.Checked)
            {
                MainFcpWorkingTime += deltaWorkingTime;
            }
            else
            {
                ReserveFcpWorkingTime += deltaWorkingTime;
            }

            if (rbPRDMain.Checked)
            {
                MainPrdWorkingTime += deltaWorkingTime;
            }
            else
            {
                ReservePrdWorkingTime += deltaWorkingTime;
            }
        }

        #endregion

        #region Работа с файлом времени наработки.

        #region Открытие файла времени наработки.
        private void OpenLogWorkingTimeFile()
        {
            try
            {
                ReadFromLogWorkingTime(ApplicationDirectory.WorkingTimeOnBoardFile);
            }
            catch (Exception)
            {
                WriteToLogWorkingTime(ApplicationDirectory.WorkingTimeOnBoardFile);
                ReadFromLogWorkingTime(ApplicationDirectory.WorkingTimeOnBoardFile);
            }
        }

        #endregion

        #region Запись в файл времени наработки.
        public static void WriteToLogWorkingTime(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8, 65536))
            {
                // Первые 4 строчки в формате удобном для Е.В.
                sw.WriteLine($"{MainFcpWorkingTime.Days}.{MainFcpWorkingTime.Hours}:{MainFcpWorkingTime.Minutes}:{MainFcpWorkingTime.Seconds}");
                sw.WriteLine($"{ReserveFcpWorkingTime.Days}.{ReserveFcpWorkingTime.Hours}:{ReserveFcpWorkingTime.Minutes}:{ReserveFcpWorkingTime.Seconds}");
                sw.WriteLine($"{MainPrdWorkingTime.Days}.{MainPrdWorkingTime.Hours}:{MainPrdWorkingTime.Minutes}:{MainPrdWorkingTime.Seconds}");
                sw.WriteLine($"{ReservePrdWorkingTime.Days}.{ReservePrdWorkingTime.Hours}:{ReservePrdWorkingTime.Minutes}:{ReservePrdWorkingTime.Seconds}");

                //sw.WriteLine(FullWorkingTime); // Полное время наработки. В релизе не используем. Считаю для себя.
            }
        }

        #endregion

        #region Чтение из файла времени наработки.
        private void ReadFromLogWorkingTime(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                MainFcpWorkingTime = TimeSpan.Parse(sr.ReadLine() ?? "0.0:0:0");
                ReserveFcpWorkingTime = TimeSpan.Parse(sr.ReadLine() ?? "0.0:0:0");
                MainPrdWorkingTime = TimeSpan.Parse(sr.ReadLine() ?? "0.0:0:0");
                ReservePrdWorkingTime = TimeSpan.Parse(sr.ReadLine() ?? "0.0:0:0");

                //FullWorkingTime = TimeSpan.Parse(sr.ReadLine());
            }
        }

        #endregion

        #endregion
    }
}

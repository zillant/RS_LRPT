using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ReceivingStation.Other;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using MaterialSkin.Controls;
using ReceivingStation.MessageBoxes;
using ReceivingStation.Properties;
using ReceivingStation.Decode;

namespace ReceivingStation
{
    /// <summary>
    /// Класс формы режима "Прием".
    /// </summary>
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

        private bool[] flags = new bool[2]; // Массив состояний демодулятора flag[0] = синхронизация фазы синхропосылки; flag[1] = захват петли ФАПЧ

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

            GuiUpdater.DecodeRichTextBoxInit(rtbMkoTitle, rtbMkoData, rtbDateTimeTitle, rtbDateTime, rtbServiceTitle, rtbServiceData);

            materialTabControl1.SelectedTab = tabPage7;

            _counterForSaveWorkingTime = TimeForSaveWorkingTime;
           
            LogFiles.ReadWorkingTimeValues(out MainFcpWorkingTime, out ReserveFcpWorkingTime, out MainPrdWorkingTime, out ReservePrdWorkingTime);

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

            _server = new Server.Server(false)
            {
                ReceivingStartedFlag = false,
                ThreadSafeChangeMode = ChangeMode,
                ThreadSafeSetReceiveParameters = SetReceiveParameters,
                ThreadSafeStartStopReceiving = StartStopReceiving,
                ThreadSafeGetSyncsStates = GetSyncsStates,
            };
            Server.Server.RemoteModeFlag = false;

            _serverThread = new Thread(_server.StartServer) {IsBackground = true};
            _serverThread.Start();

            timer1.Start();
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
                if (pModulation.Visible)
                {
                    pModulation.Visible = false;
                }
                else
                {
                    pModulation.Visible = true;
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
                if (_server.ReceivingStartedFlag)
                {
                    CountWorkingTime();
                    _startWorkingTime = DateTime.Now;
                    LogFiles.WriteWorkingTimeValues(MainFcpWorkingTime, ReserveFcpWorkingTime, MainPrdWorkingTime, ReservePrdWorkingTime);
                }
                _counterForSaveWorkingTime = TimeForSaveWorkingTime;
            }

            if (_server.ReceivingStartedFlag && _receiver != null)
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

        #region Установка параметров записи потока.

        /// <summary>
        /// Установка параметров записи потока в местном режиме управления.
        /// </summary>
        private void SetReceiveParameters()
        {
            _fcp = Convert.ToByte(rbFCPMain.Checked ? 0x1 : 0x2);
            _prd = Convert.ToByte(rbPRDMain.Checked ? 0x1 : 0x2);
            _freq = Convert.ToByte(rbFreq1.Checked ? 0x1 : 0x2);
            _interliving = Convert.ToByte(rbInterlivingReceiveOn.Checked ? 0x1 : 0x2);
        }

        /// <summary>
        /// Установка параметров записи потока в дистанционном режиме управления.
        /// </summary>
        /// <remarks>
        /// Связан с делегатом ThreadSafeSetReceiveParameters в потоке сервера.      
        /// </remarks>
        /// <param name="fcp">Значение ФЦП.</param>
        /// <param name="prd">Значение ПРД.</param>
        /// <param name="freq">Значение несущей частоты.</param>
        /// <param name="interliving">Значение интеливинга.</param>
        private void SetReceiveParameters(byte fcp, byte prd, byte freq, byte interliving)
        {
            _fcp = fcp;
            _prd = prd;
            _freq = freq;
            _interliving = interliving;

            Invoke(new Action(() => { SetRadioButtons(_fcp, rbFCPMain, rbFCPReserve); }));
            Invoke(new Action(() => { SetRadioButtons(_prd, rbPRDMain, rbPRDReserve); }));
            Invoke(new Action(() => { SetRadioButtons(_freq, rbFreq1, rbFreq2); }));
            Invoke(new Action(() => { SetRadioButtons(_interliving, rbInterlivingReceiveOn, rbInterlivingReceiveOff); }));
        }

        /// <summary>
        /// Смена состояний RadioButton для установка параметров записи потока в дистанционном режиме управления.
        /// </summary>
        /// <param name="param">Параметр.</param>
        /// <param name="rb1">Первый RadioButton параметра.</param>
        /// <param name="rb2">Второй RadioButton параметра.</param>
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

        #region Начать/Остановить прием потока.

        /// <summary>
        /// Начать/Остановить прием потока.
        /// </summary> 
        /// <remarks>
        /// Создает имя, приемник и декодер текущего сеанса.
        /// Очищает контролы от предыдущего сеанса.
        /// Связан с делегатом ThreadSafeStartStopReceiving в потоке сервера.  
        /// </remarks>
        public void StartStopReceiving()
        {
            if (!_server.ReceivingStartedFlag)
            {               
                if (!Server.Server.RemoteModeFlag)
                {
                    SetReceiveParameters();                   
                }

                _server.ReceivingStartedFlag = true;
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
                _fileName = $"{ApplicationDirectory.GetCurrentSessionDirectory($"{sessionName}")}\\{sessionName}.dat";
          
                // Очистка всего перед новым запуском.
                for (int i = 0; i < 6; i++)
                {
                    _allChannels[i].Controls.Clear();
                    _channels[i].Controls.Clear();
                    _listImagesForSave[i].Clear();

                    Directory.CreateDirectory($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_Channel_{i + 1}");
                    DirectoryInfo di = new DirectoryInfo($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_Channel_{i + 1}");

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                }

                _startWorkingTime = DateTime.Now;
                _imageCounter = 0;              

                LogFiles.WriteUserActions($"Установлены параметры: ФПЦ - {_fcp}, ПРД - {_prd}, Частота - {_freq}, Интерливинг - {_interliving}");
                LogFiles.WriteUserActions("Запись потока начата");                

                if (rbOqpsk.Checked) _modulation = 0x2;
                if (rbQpsk.Checked) _modulation = 0x1;

                var isSelfTest = false;

                _decode = new Decode.Decode(_fileName) { ThreadSafeUpdateGui = UpdateGuiDecodeData };
                _receiver = new Demodulator.Demodulating(this, _fileName, _freq, _interliving, _modulation, _decode);
                
                _receiver.Dongle_Configuration(1024000); // инициализируем свисток, в нем отсчеты записываются в поток
                _receiver.StartDecoding();
                _receiver.RecordStart(isSelfTest);

                lblDemOn.SetPropertyThreadSafe(() => lblDemOn.Text, "Демодулятор включен");
                lblDongOn.SetPropertyThreadSafe(() => lblDongOn.Text, "Приемник включен");
            }
            else
            {
                 StopReceiving();
            }

        }

        /// <summary>
        /// Остановить прием потока.
        /// </summary> 
        /// <remarks>
        /// Логика остановки приема потока.
        /// </remarks>
        private void StopReceiving()
        {
            _decode.UpdateDataGui();
            _decode.FinishDecode();

            _server.ReceivingStartedFlag = false;
            _receiver.StopDecoding();

            try
            {
                bwImageSaver.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            

            btnStartRecieve.SetPropertyThreadSafe(() => btnStartRecieve.Text, "Начать");
            lblDemOn.SetPropertyThreadSafe(() => lblDemOn.Text, "Демодулятор выключен");
            lblDongOn.SetPropertyThreadSafe(() => lblDongOn.Text, "Приемник выключен");
            lblLockOn.SetPropertyThreadSafe(() => lblLockOn.Text, "");
            lblSignDetect.SetPropertyThreadSafe(() => lblSignDetect.Text, "");

            tlpReceivingParameters.SetPropertyThreadSafe(() => tlpReceivingParameters.Enabled, true);

            CountWorkingTime();
            LogFiles.WriteWorkingTimeValues(MainFcpWorkingTime, ReserveFcpWorkingTime, MainPrdWorkingTime, ReservePrdWorkingTime);
            LogFiles.WriteUserActions("Запись потока завершена");

            // Чтобы при удаленной работе не выскакивало информационное окно.
            if (!Server.Server.RemoteModeFlag)
            {
                FormInformationMessageBox.Show("Сообщение", "Прием потока завершен.", Resources.done_icon, "Перейти в", "каталог с результатами", _fileName);
            }
        }

        #endregion

        /// <summary>
        /// Смена режима управления.
        /// </summary>
        /// <remarks>
        /// Нужно для работы с ИВК.
        /// Связан с делегатом ThreadSafeChangeMode в потоке сервера.      
        /// </remarks>
        /// <param name="modeNumber">Номер режима управления. 0 - ДУ, 1 - МУ.</param>
        private void ChangeMode(byte modeNumber)
        {
            if (modeNumber == 0)
            {              
                // Дистанционное управление
                tlp1.SetPropertyThreadSafe(() => tlp1.Enabled, false);
                Invoke(new Action(() => { slMode.Text = Resources.RemoteControlString; }));

                LogFiles.WriteUserActions(Resources.RemoteControlString);
            }
            else if (modeNumber == 1)
            {
                // Местное управление
                tlp1.SetPropertyThreadSafe(() => tlp1.Enabled, true);
                Invoke(new Action(() => { slMode.Text = Resources.LocalControlString; }));

                LogFiles.WriteUserActions(Resources.LocalControlString);
            }
        }

        /// <summary>
        /// Расчет времени наработки каждого полукомплекта.
        /// </summary>
        private void CountWorkingTime()
        {
            DateTime finishWorkingTime = DateTime.Now;
            TimeSpan deltaWorkingTime = finishWorkingTime - _startWorkingTime;
            FullWorkingTime += deltaWorkingTime; // Общее время наработки (не используется).

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

        /// <summary>
        /// Получение статусов синхронизации для ИВК в режиме ДУ.
        /// </summary>
        /// <remarks>
        /// Связан с делегатом ThreadSafeGetSyncsStates в потоке сервера.      
        /// </remarks>
        public bool[] GetSyncsStates()
        {
            bool[] syncsStatesValues = new bool[2];
            syncsStatesValues[0] = flags[0];
            syncsStatesValues[1] = _interliving == 0x1 ? true : false;

            return syncsStatesValues;
        }

        #region Обновление GUI.

        /// <summary>
        /// Обновление данных декодирования на GUI.
        /// </summary>
        /// <remarks>
        /// Связан с делегатом ThreadSafeUpdateGui в потоке декодирования.
        /// Каждые 60 вызовов этой функции вызывается сохранение полученных изображений.
        /// </remarks>
        /// <param name="linesDate">Значения Даты и времени полученной полосы.</param>
        /// <param name="linesService">Значения служебной информации полученной полосы.</param>
        /// <param name="linesTd">Значения ТД полученной полосы.</param>
        /// <param name="linesOshv">Значения ОШВ полученной полосы.</param>
        /// <param name="linesBshv">Значения БШВ полученной полосы.</param>
        /// <param name="linesPcdm">Значения ПЦДМ полученной полосы.</param>
        /// <param name="imagesLines">Полученные полосы изображений по каждому каналу.</param>
        private void UpdateGuiDecodeData(DateTime linesDate, string linesService, string linesTd, string linesOshv, string linesBshv, string linesPcdm, DirectBitmap[] imagesLines, int delegateCallCounter)
        {
            // Набрал 6400 строчек изображения (8 * 800).
            if (delegateCallCounter == Constants.DELEGATE_CALL_COUNTER)
            {
                bwImageSaver.RunWorkerAsync();
            }

            if (InvokeRequired)
            {
                Invoke(new Action(() => GuiUpdater.UpdateGuiDecodeData(linesService, linesTd, linesOshv, linesBshv, linesPcdm, linesDate,
                    rtbDateTime, rtbMkoData, rtbServiceData, _channels, _allChannels, _channelsPanels, _allChannelsPanels, _listImagesForSave, imagesLines)));
            }
        }

        /// <summary>
        /// Обновление данных демодуляции на GUI.
        /// </summary>
        /// <param name="flags">Массив состояний демодулятора.</param>
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
    }
}

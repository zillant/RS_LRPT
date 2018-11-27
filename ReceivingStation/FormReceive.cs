using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReceivingStation.Other;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using MaterialSkin.Controls;
using ReceivingStation.Properties;

namespace ReceivingStation
{
    public partial class FormReceive : MaterialForm
    {
        public bool remoteModeFlag;

        private const int TimeForSaveWorkingTime = 1800; // Время для таймера (сек), через которое нужно сохранять наработку в файл. 

        private string WorkingTimeOnboardFileName = Settings.Default.OnboardWorkingTimeFileName;

        private Thread _serverThread;
        
        private FlowLayoutPanel[] _channels = new FlowLayoutPanel[6];
        private FlowLayoutPanel[] _allChannels = new FlowLayoutPanel[6];
        private List<Bitmap>[] _listImagesForSave = new List<Bitmap>[6];

        private DateTime _startWorkingTime; // Время начала работы борта.
        private TimeSpan _mainFCPWorkingTime;
        private TimeSpan _reserveFCPWorkingTime;
        private TimeSpan _mainPRDWorkingTime;
        private TimeSpan _reservePRDWorkingTime;
        private TimeSpan _fullWorkingTime; // Общее время работы системы.

        private int _counterForSaveWorkingTime; // Счетчик для таймера, через которое нужно сохранять время наработки в файл.

        private bool _isReceivingStarting; // Для контроля времени наработки борта.

        // private Demodulating _receiver;
        private Server _server;

        // Параметры приема битового потока.
        private byte _fcp;
        private byte _prd;
        private byte _freq;
        private byte _interliving;

        public FormReceive()
        {
            InitializeComponent();            
            GuiUpdater.SmoothLoadingForm(this);           
        }

        private void FormReceive_Load(object sender, EventArgs e)
        {
            materialTabControl1.SelectedTab = tabPage7;

            remoteModeFlag = false;
            _isReceivingStarting = false;
            _counterForSaveWorkingTime = TimeForSaveWorkingTime;
            
            for (int i = 0; i < 6; i++)
            {
                _listImagesForSave[i] = new List<Bitmap>();
            }

            try
            {
                ReadFromLogWorkingTime(WorkingTimeOnboardFileName);
                DisplayWorkingTime();
            }
            catch (Exception)
            {
                WriteToLogWorkingTime(WorkingTimeOnboardFileName);
                ReadFromLogWorkingTime(WorkingTimeOnboardFileName);
                DisplayWorkingTime();
            }

            _channels[0] = flpChannel1;
            _channels[1] = flpChannel2;
            _channels[2] = flpChannel3;
            _channels[3] = flpChannel4;
            _channels[4] = flpChannel5;
            _channels[5] = flpChannel6;

            _allChannels[0] = flpAllChannels1;
            _allChannels[1] = flpAllChannels2;
            _allChannels[2] = flpAllChannels3;
            _allChannels[3] = flpAllChannels4;
            _allChannels[4] = flpAllChannels5;
            _allChannels[5] = flpAllChannels6;

            slTime.Text = DateTime.Now.ToString();
            timer1.Start();

            _server = new Server(this)
            {
                ThreadSafeChangeMode = ChangeMode,
                ThreadSafeSetReceiveParameters = SetReceiveParameters,
                ThreadSafeStartReceiving = StartStopReceiving,
                ThreadSafeStopReceiving = StopReceiving
            };

            _serverThread = new Thread(new ThreadStart(_server.StartServer));
            _serverThread.IsBackground = true;
            _serverThread.Start();            
        }

        private void FormReceive_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = FormCloseMessageBox.Show();

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void FormReceive_FormClosed(object sender, FormClosedEventArgs e)
        {
            _server.stopThread = true;
            _serverThread.Join(100);

            Application.Exit();
        }

        private void btnStartRecieve_Click(object sender, EventArgs e)
        {           
            StartStopReceiving();
        }

        private void slMode_DoubleClick(object sender, EventArgs e)
        {
            using (FormModeSettings modeSettingsForm = new FormModeSettings(this))
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            slTime.Text = DateTime.Now.ToString();

            _counterForSaveWorkingTime -= 1;
           
            if (_counterForSaveWorkingTime == 0)
            {
                if (_isReceivingStarting)
                {
                    CountWorkingTime();
                    _startWorkingTime = DateTime.Now;
                    WriteToLogWorkingTime(WorkingTimeOnboardFileName);
                    DisplayWorkingTime();
                }
                _counterForSaveWorkingTime = TimeForSaveWorkingTime;
            }
        }

        private void bwImageSaver_DoWork(object sender, DoWorkEventArgs e)
        {
            Parallel.For(0, _listImagesForSave.Length, i =>
            {
                using (Bitmap bmp = new Bitmap(Constants.WDT, _listImagesForSave[i].Count * Constants.HGT))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        int yOffset = 0;

                        for (int j = 0; j < _listImagesForSave[i].Count; j++)
                        {
                            g.DrawImage(_listImagesForSave[i][j], new Rectangle(0, yOffset, Constants.WDT, Constants.HGT));
                            yOffset += Constants.HGT;
                        }
                    }

                    //bmp.Save($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_{i}.bmp");
                }
            });
        }

        #region Смена режима управления.
        private void ChangeMode(byte modeNumber)
        {
            if (modeNumber == 0)
            {
                // Дистанционное управление
                tlpReceiveSettings.Enabled = false;
                slMode.Text = "Дистанционное управление";
                WriteToLogUserActions("Дистанционное управление");
                remoteModeFlag = true;
            }
            else if (modeNumber == 1)
            {
                // Местное управление
                tlpReceiveSettings.Enabled = true;
                slMode.Text = "Местное управление";
                WriteToLogUserActions("Местное управление");
                remoteModeFlag = false;
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

        #region Начать прием потока.
        public void StartStopReceiving()
        {
            if (!_isReceivingStarting)
            {
                _isReceivingStarting = true;
                btnStartRecieve.Text = "Остановить";

                if (!remoteModeFlag)
                {
                    SetReceiveParameters();
                }

                _startWorkingTime = DateTime.Now;
                WriteToLogUserActions($"Установлены параметры: ФПЦ - {_fcp}, ПРД - {_prd}, Частота - {_freq}, Интерливинг - {_interliving}");
                WriteToLogUserActions("Запись потока начата");

                //_receiver = new Demodulating(_freq);
                //_receiver.Dongle_Configuration(1024000);// инициализируем свисток, в нем отсчеты записываются в поток
                //Task.Run(() => Drawing());
            }
            else
            {
                StopReceiving();
            }
                              
        }

        //public void Drawing()
        //{
        //    byte[] demodulatedData;
        //    demodulatedData = new byte[16384 * 5];

        //    _receiver.DSP_Process(this, demodulatedData);
        //    _decode.StartDecode(demodulatedData);           
        //}
      
        #endregion

        #region Остановить прием потока.
        public void StopReceiving()
        {
            _isReceivingStarting = false;
            btnStartRecieve.Text = "Начать";

            CountWorkingTime();
            WriteToLogWorkingTime(WorkingTimeOnboardFileName);
            DisplayWorkingTime();

            WriteToLogUserActions("Запись потока завершена");
        }

        #endregion

        #region Обновление счетчика кадров при декодировании.
        private void UpdateFrameCounterValue(uint counter)
        {
            GuiUpdater.SetLabelText(lblFramesCounter, counter.ToString());
        }

        #endregion

        #region Обновление изображений при декодировании.
        private void UpdateChannelsImages(DirectBitmap[] images)
        {
            GuiUpdater.AddImages(_channels, _allChannels, _listImagesForSave, images);

            bwImageSaver.RunWorkerAsync();
        }

        #endregion
     
        #region Запись в лог файл действий пользователя.
        private void WriteToLogUserActions(string logMessage)
        {
            using (StreamWriter sw = new StreamWriter("log.txt", true, Encoding.UTF8, 65536))
            {
                sw.WriteLine($"{DateTime.Now} - {logMessage}");
            }
        }

        #endregion

        #region Расчет времени наработки.
        private void CountWorkingTime()
        {
            DateTime finishWorkingTime = DateTime.Now;
            TimeSpan deltaWorkingTime = finishWorkingTime - _startWorkingTime;
            _fullWorkingTime += deltaWorkingTime;

            if (rbFCPMain.Checked)
            {
                _mainFCPWorkingTime += deltaWorkingTime;
            }
            else
            {
                _reserveFCPWorkingTime += deltaWorkingTime;
            }

            if (rbPRDMain.Checked)
            {
                _mainPRDWorkingTime += deltaWorkingTime;
            }
            else
            {
                _reservePRDWorkingTime += deltaWorkingTime;
            }
        }

        #endregion

        #region Запись в лог файл времени наработки.
        private void WriteToLogWorkingTime(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8, 65536))
            {
                sw.WriteLine(_mainFCPWorkingTime);
                sw.WriteLine(_reserveFCPWorkingTime);
                sw.WriteLine(_mainPRDWorkingTime);
                sw.WriteLine(_reservePRDWorkingTime);
                sw.WriteLine(_fullWorkingTime);
            }
        }

        #endregion

        #region Чтение из лог файла времени наработки.
        private void ReadFromLogWorkingTime(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                _mainFCPWorkingTime = TimeSpan.Parse(sr.ReadLine());
                _reserveFCPWorkingTime = TimeSpan.Parse(sr.ReadLine());
                _mainPRDWorkingTime = TimeSpan.Parse(sr.ReadLine());
                _reservePRDWorkingTime = TimeSpan.Parse(sr.ReadLine());
                _fullWorkingTime = TimeSpan.Parse(sr.ReadLine());                           
            }
        }

        #endregion

        #region Отображение времени наработки.
        private void DisplayWorkingTime()
        {
            slWorkingTimeOnboard.Text = $"{(long)_fullWorkingTime.TotalHours}:{_fullWorkingTime.Minutes.ToString("D2")}:{_fullWorkingTime.Seconds.ToString("D2")}";
        }

        #endregion
    }
}

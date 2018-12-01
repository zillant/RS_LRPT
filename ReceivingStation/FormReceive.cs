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
        public static TimeSpan MainFcpWorkingTime;
        public static TimeSpan ReserveFcpWorkingTime;
        public static TimeSpan MainPrdWorkingTime;
        public static TimeSpan ReservePrdWorkingTime;
        public static TimeSpan FullWorkingTime; // Общее время работы системы. (Не используем в релизе) 

        public bool remoteModeFlag;

        private const int TimeForSaveWorkingTime = 1800; // Время для таймера (сек), через которое нужно сохранять наработку в файл. 

        private Thread _serverThread;

        private string _fileName;
        private int _callingUpdateImageCounter;
        private long _imageCounter;
        private uint _frameCounter;
        private string[] _td = new string[4];
        private string[] _oshv = new string[2];
        private string[] _bshv = new string[10];
        private string[] _pcdm = new string[14];
        private DirectBitmap[] _images = new DirectBitmap[6];

        private Panel[] _allChannelsPanels = new Panel[6];
        private Panel[] _channelsPanels = new Panel[6];
        private FlowLayoutPanel[] _channels = new FlowLayoutPanel[6];
        private FlowLayoutPanel[] _allChannels = new FlowLayoutPanel[6];
        private List<Bitmap>[] _listImagesForSave = new List<Bitmap>[6];

        private DateTime _startWorkingTime; // Время начала работы борта.

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
        }

        private void FormReceive_Load(object sender, EventArgs e)
        {
            GuiUpdater.SmoothLoadingForm(this);

            materialTabControl1.SelectedTab = tabPage7;

            remoteModeFlag = false;
            _isReceivingStarting = false;
            _counterForSaveWorkingTime = TimeForSaveWorkingTime;

            OpenLogWorkingTimeFile();

            _channelsPanels[0] = pScroll1;
            _channelsPanels[1] = pScroll2;
            _channelsPanels[2] = pScroll3;
            _channelsPanels[3] = pScroll4;
            _channelsPanels[4] = pScroll5;
            _channelsPanels[5] = pScroll6;

            _allChannelsPanels[0] = pScroll7;
            _allChannelsPanels[1] = pScroll8;
            _allChannelsPanels[2] = pScroll9;
            _allChannelsPanels[3] = pScroll10;
            _allChannelsPanels[4] = pScroll11;
            _allChannelsPanels[5] = pScroll12;

            for (int i = 0; i < 6; i++)
            {
                _allChannels[i] = GuiUpdater.GetFlp($"flpAllChannels{i}", new Size(242, 8));
                _channels[i] = GuiUpdater.GetFlp($"flpChannel{i}", new Size(1556, 40));
                _allChannelsPanels[i].Controls.Add(_allChannels[i]);
                _channelsPanels[i].Controls.Add(_channels[i]);
                _listImagesForSave[i] = new List<Bitmap>();
            }

            slTime.Text = DateTime.Now.ToString();
            timer1.Start();

            _server = new Server(this)
            {
                ThreadSafeChangeMode = ChangeMode,
                ThreadSafeSetReceiveParameters = SetReceiveParameters,
                ThreadSafeStartReceiving = StartStopReceiving,
                ThreadSafeStopReceiving = StopReceiving
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
                    WriteToLogWorkingTime(Settings.Default.OnboardWorkingTimeFileName);
                }
                _counterForSaveWorkingTime = TimeForSaveWorkingTime;
            }
        }

        private void bwImageSaver_DoWork(object sender, DoWorkEventArgs e)
        {
            Parallel.For(0, _listImagesForSave.Length, SaveImage);
            _imageCounter += 1;
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

                // Очистка всего перед новым запуском.
                //for (int i = 0; i < 6; i++)
                //{
                //    _allChannels[i].Controls.Clear();
                //    _channels[i].Controls.Clear();
                //    _listImagesForSave[i].Clear();
                //    Directory.CreateDirectory($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_Channel_{i + 1}");
                //    DirectoryInfo di = new DirectoryInfo($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_Channel_{i + 1}");

                //    foreach (FileInfo file in di.GetFiles())
                //    {
                //        file.Delete();
                //    }
                //}

                _startWorkingTime = DateTime.Now;
                _imageCounter = 0;
                _callingUpdateImageCounter = 0;
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
            WriteToLogWorkingTime(Settings.Default.OnboardWorkingTimeFileName);

            WriteToLogUserActions("Запись потока завершена");
        }

        #endregion

        #region Обновление счетчика кадров при декодировании.
        private void UpdateFrameCounterValue(uint counter)
        {
            _frameCounter = counter;
        }

        #endregion

        #region Обновление изображений при декодировании.
        private void UpdateChannelsImages(DirectBitmap[] images)
        {
            _images = images;

            _callingUpdateImageCounter++;

            // Набрал 480 строчек изображения (8 * 60).
            if (_callingUpdateImageCounter == 60)
            {
                bwImageSaver.RunWorkerAsync();
                _callingUpdateImageCounter = 0;
            }
        }

        #endregion

        #region Обновление МКО при декодировании.

        private void UpdateMko(string tdd, string oshvv, string bshvv, string pcdmm)
        {
            _td = tdd.Split(' ');
            _oshv = oshvv.Split(' ');
            _bshv = bshvv.Split(' ');
            _pcdm = pcdmm.Split(' ');
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
                ReadFromLogWorkingTime(Settings.Default.OnboardWorkingTimeFileName);
            }
            catch (Exception)
            {
                WriteToLogWorkingTime(Settings.Default.OnboardWorkingTimeFileName);
                ReadFromLogWorkingTime(Settings.Default.OnboardWorkingTimeFileName);
            }
        }

        #endregion

        #region Запись в файл времени наработки.
        public static void WriteToLogWorkingTime(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8, 65536))
            {
                sw.WriteLine(MainFcpWorkingTime);
                sw.WriteLine(ReserveFcpWorkingTime);
                sw.WriteLine(MainPrdWorkingTime);
                sw.WriteLine(ReservePrdWorkingTime);
                sw.WriteLine(FullWorkingTime);
            }
        }

        #endregion

        #region Чтение из файла времени наработки.
        private void ReadFromLogWorkingTime(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                MainFcpWorkingTime = TimeSpan.Parse(sr.ReadLine());
                ReserveFcpWorkingTime = TimeSpan.Parse(sr.ReadLine());
                MainPrdWorkingTime = TimeSpan.Parse(sr.ReadLine());
                ReservePrdWorkingTime = TimeSpan.Parse(sr.ReadLine());
                FullWorkingTime = TimeSpan.Parse(sr.ReadLine());
            }
        }

        #endregion

        #endregion

        #region Сохранение изображений.
        private void SaveImage(int i)
        {
            List<Bitmap> listImages = new List<Bitmap>(_listImagesForSave[i]);
            _listImagesForSave[i].Clear();

            using (Bitmap bmp = new Bitmap(Constants.WDT, listImages.Count * Constants.HGT))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    int yOffset = 0;

                    for (int j = 0; j < listImages.Count; j++)
                    {
                        g.DrawImage(listImages[j], new Rectangle(0, yOffset, Constants.WDT, Constants.HGT));
                        yOffset += Constants.HGT;
                    }
                }

                //bmp.Save($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_Channel_{i + 1}\\{Path.GetFileNameWithoutExtension(_fileName)}_{i + 1}_{_imageCounter}.bmp");
            }
        }

        #endregion

        #region Обновление GUI.
        private void UpdateGui()
        {
            GuiUpdater.SetLabelText(lblFramesCounter, _frameCounter.ToString());
            // ТД.
            GuiUpdater.SetLabelText(lblTD1, $"{_td[0]} {_td[1]}");
            GuiUpdater.SetLabelText(lblTD2, $"{_td[2]}");
            GuiUpdater.SetLabelText(lblTD3, $"{_td[3]}");
            // ОШВ.
            GuiUpdater.SetLabelText(lblOSHV1, $"{_oshv[0]} {_oshv[1]}");
            // БШВ.
            GuiUpdater.SetLabelText(lblBSHV1, $"{_bshv[0]} {_bshv[1]}");
            GuiUpdater.SetLabelText(lblBSHV2, $"{_bshv[2]} {_bshv[3]}");
            GuiUpdater.SetLabelText(lblBSHV3, $"{_bshv[4]} {_bshv[5]}");
            GuiUpdater.SetLabelText(lblBSHV4, $"{_bshv[6]} {_bshv[7]}");
            GuiUpdater.SetLabelText(lblBSHV5, $"{_bshv[8]} {_bshv[9]}");
            // ПЦДМ.
            GuiUpdater.SetLabelText(lblPCDM1, $"{_pcdm[0]} {_pcdm[1]}");
            GuiUpdater.SetLabelText(lblPCDM2, $"{_pcdm[2]} {_pcdm[3]} {_pcdm[4]} {_pcdm[5]}");
            GuiUpdater.SetLabelText(lblPCDM3, $"{_pcdm[6]} {_pcdm[7]} {_pcdm[8]} {_pcdm[9]}");
            GuiUpdater.SetLabelText(lblPCDM4, $"{_pcdm[10]} {_pcdm[11]} {_pcdm[12]} {_pcdm[13]}");
            // Изображение.
            GuiUpdater.CreateNewFlps(_channels, _allChannels, _channelsPanels, _allChannelsPanels);
            GuiUpdater.AddImages(_channels, _allChannels, _listImagesForSave, _images);
        }

        #endregion
    }
}

using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReceivingStation.Other;
using System.Text;

namespace ReceivingStation
{
    public partial class MainForm : Form
    {
        private const int _timeForSaveWorkingTime = 1800; // Время для таймера (сек), через которое нужно сохранять наработку в файл. 
        private const string _workingTimeOnboardFileName = "working_time_onboard.txt";

        private Decode.Decode _decode;
        private string _fileName;
        private bool _remoteModeFlag;

        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;

        private PictureBox[] _channels = new PictureBox[6];
        private PictureBox[] _allChannels = new PictureBox[6];
        private Bitmap[] _images = new Bitmap[6];

        private DateTime _startWorkingTimeOnboard; // Время начала работы борта.
        private TimeSpan _fullWorkingTimeOnboard;
        private int _counterForSaveWorkingTime; // Счетчик для таймера, через которое нужно сохранять время наработки в файл.

        private bool _isReceivingStarting;

        // Параметры приема битового потока.
        private byte _fcp;
        private byte _prd;
        private byte _freq;
        private byte _interliving;

        public MainForm()
        {
            InitializeComponent();

            tabControl1.SelectedTab = tabPage7;
            _remoteModeFlag = false;

            try
            {
                ReadFromLogWorkingTime(_workingTimeOnboardFileName, out _fullWorkingTimeOnboard, slWorkingTimeOnboard);
            }
            catch (Exception)
            {
                WriteToLogWorkingTime(_workingTimeOnboardFileName, "0:0:0");
                ReadFromLogWorkingTime(_workingTimeOnboardFileName, out _fullWorkingTimeOnboard, slWorkingTimeOnboard);
            }

            Decode.Decode.ThreadCounterUpdater = UpdateCounter;
            Decode.Decode.ThreadImageUpdater = UpdateImage;
            Decode.Decode.ThreadStopDecoding = StopDecoding;

            Server.Server.ThreadChangeMode = ChangeMode;
            Server.Server.ThreadSetParameters = RemoteSetReceiveParameters;
            Server.Server.ThreadStartReceiving = RemoteStartReceiving;
            Server.Server.ThreadStopReceiving = RemoteStopReceiving;

            _channels[0] = pChannel1;
            _channels[1] = pChannel2;
            _channels[2] = pChannel3;
            _channels[3] = pChannel4;
            _channels[4] = pChannel5;
            _channels[5] = pChannel6;

            _allChannels[0] = pACChannel1;
            _allChannels[1] = pACChannel2;
            _allChannels[2] = pACChannel3;
            _allChannels[3] = pACChannel4;
            _allChannels[4] = pACChannel5;
            _allChannels[5] = pACChannel6;

            slTime.Text = DateTime.Now.ToString();
            _counterForSaveWorkingTime = _timeForSaveWorkingTime;

            timer1.Start();

            _isReceivingStarting = false;
            var server = new Server.Server();
            Task.Run(() => server.StartServer());          
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();           
        }

        private void tsmiFileOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Title = "Выбор файла телеметрии";
                openFileDialog1.Filter = "Telemetry files (*.dat)|*.dat";
                openFileDialog1.FilterIndex = 1;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    _fileName = openFileDialog1.FileName;
                    lblFileName.Text = openFileDialog1.SafeFileName;
                }

                btnStartDecode.Enabled = true;
                tsmiStartDecoding.Enabled = true;
            }          
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            using (SettingsForm settingsForm = new SettingsForm())
            {
                settingsForm.ShowDialog();
            }
        }

        private void tsmiStartDecoding_Click(object sender, EventArgs e)
        {
            StartDecoding();
        }

        private void tsmiStopDecoding_Click(object sender, EventArgs e)
        {
            ForcedStopDecoding();           
        }

        private void btnStartRecieve_Click(object sender, EventArgs e)
        {
            _isReceivingStarting = true;
            btnStartRecieve.Enabled = false;
            btnStopRecieve.Enabled = true;
            StartReceiving();
        }

        private void btnStopRecieve_Click(object sender, EventArgs e)
        {
            _isReceivingStarting = false;
            btnStartRecieve.Enabled = true;
            btnStopRecieve.Enabled = false;
            StopReceiving();
        }

        private void btnStartDecode_Click(object sender, EventArgs e)
        {
            StartDecoding();
        }

        private void btnStopDecode_Click(object sender, EventArgs e)
        {
            ForcedStopDecoding();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            slTime.Text = DateTime.Now.ToString();

            _counterForSaveWorkingTime -= 1;

            if (_counterForSaveWorkingTime == 0)
            {
                if (_isReceivingStarting)
                {
                    CountWorkingTime(ref _fullWorkingTimeOnboard);
                    _startWorkingTimeOnboard = DateTime.Now;
                    WriteToLogWorkingTime(_workingTimeOnboardFileName, _fullWorkingTimeOnboard.ToString());
                }
                _counterForSaveWorkingTime = _timeForSaveWorkingTime;
            }
        }

        #region Смена режима управления.
        private void ChangeMode(byte modeNumber)
        {
            if (InvokeRequired == false)
            {
                if (modeNumber == 0)
                {
                    // Дистанционное управление
                    Enabled = false;
                    slMode.Text = "Дистанционное управление";
                    WriteToLogUserActions("Дистанционное управление");
                    _remoteModeFlag = true;
                }
                else if (modeNumber == 1)
                {
                    // Местное управление
                    Enabled = true;
                    slMode.Text = "Местное управление";
                    WriteToLogUserActions("Местное управление");
                    _remoteModeFlag = false;
                }
            }
            else
            {
                Server.Server.ChangeMode changeMode = ChangeMode;
                Invoke(changeMode, modeNumber);
            }
        }

        #endregion

        #region Установка параметров записи потока в дистанционном режиме управления.
        private void RemoteSetReceiveParameters(byte fcp, byte prd, byte freq, byte interliving)
        {
            if (InvokeRequired == false)
            {
                _fcp = fcp;
                _prd = prd;
                _freq = freq;
                _interliving = interliving;
                WriteToLogUserActions($"Установлены параметры: ФПЦ - {_fcp}, ПРД - {_prd}, Частота - {_freq}, Интерливинг - {_interliving}");
            }
            else
            {
                Server.Server.SetParameters setParameters = RemoteSetReceiveParameters;
                Invoke(setParameters, fcp, prd, freq, interliving);
            }
        }

        #endregion

        #region Установка параметров записи потока в местном режиме управления.
        private void LocalSetReceiveParameters()
        {
            _fcp = Convert.ToByte((rbFCPMain.Checked) ? 0x1 : 0x2);
            _prd = Convert.ToByte((rbPRDMain.Checked) ? 0x1 : 0x2);
            _freq = Convert.ToByte((rbFreq1.Checked) ? 0x1 : 0x2);
            _interliving = Convert.ToByte((rbInterlivingReceiveOn.Checked) ? 0x1 : 0x2);
            WriteToLogUserActions($"Установлены параметры: ФПЦ - {_fcp}, ПРД - {_prd}, Частота - {_freq}, Интерливинг - {_interliving}");
        }

        #endregion

        #region Начать прием потока.
        public void StartReceiving()
        {
            if (!_remoteModeFlag)
            {
                LocalSetReceiveParameters();
            }
            _startWorkingTimeOnboard = DateTime.Now;

            WriteToLogUserActions("Запись потока начата");
            // Receiver receiver = new Receiver(_fcp, _prd, _freq, _interliving);
            // receiver.StartReceive();

        }

        #endregion

        #region Остановить прием потока.
        public void StopReceiving()
        {
            CountWorkingTime(ref _fullWorkingTimeOnboard);
            WriteToLogWorkingTime(_workingTimeOnboardFileName, _fullWorkingTimeOnboard.ToString());
        }

        #endregion

        #region Начать прием потока в дистанционном режиме управления.
        public void RemoteStartReceiving()
        {
            if (InvokeRequired == false)
            {
                StartReceiving();
            }
            else
            {
                Server.Server.StartReceiving remoteStartReceiving = RemoteStartReceiving;
                Invoke(remoteStartReceiving);
            }
        }

        #endregion

        #region Остановить прием потока в дистанционном режиме управления.
        public void RemoteStopReceiving()
        {
            if (InvokeRequired == false)
            {
                StopReceiving();
            }
            else
            {
                Server.Server.StartReceiving remoteStartReceiving = RemoteStartReceiving;
                Invoke(remoteStartReceiving);
            }
        }

        #endregion

        #region Начать декодирование.
        private void StartDecoding()
        {
            bool reedSoloFlag = rbRSYes.Checked;
            bool nrzFlag = rbNRZYes.Checked;

            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;

            _decode = new Decode.Decode(this, _fileName, reedSoloFlag, nrzFlag);
            Task.Run(() => _decode.StartDecode(_cancellationToken));


            for (int i = 0; i < 6; i++)
            {
                _images[i] = new Bitmap(1, 1);
                _allChannels[i].Image = _images[i];
                _channels[i].Image = _images[i];
            }

            btnStartDecode.Enabled = false;
            tsmiStartDecoding.Enabled = false;
            btnStopDecode.Enabled = true;
            tsmiStopDecoding.Enabled = true;
            gbDecodeParameters.Enabled = false;
        }

        #endregion

        #region Обновление счетчика кадров при декодировании.
        private void UpdateCounter(uint counter)
        {
            lblFramesCounter.Text = counter.ToString();            
        }

        #endregion

        #region Обновление изображений при декодировании.
        private void UpdateImage(Bitmap[] images)
        {
            for (int i = 0; i < 6; i++)
            {
                _images[i].Dispose();
                _images[i] = new Bitmap(images[i]);
                _allChannels[i].Image = _images[i];
                _channels[i].Image = _images[i];               
            };
        }

        #endregion

        #region Остановка декодирования.
        private void StopDecoding()
        {
            if (InvokeRequired == false)
            {
                btnStartDecode.Enabled = true;
                tsmiStartDecoding.Enabled = true;
                btnStopDecode.Enabled = false;
                tsmiStopDecoding.Enabled = false;
                gbDecodeParameters.Enabled = true;
            }
            else
            {
                Decode.Decode.StopDecoding stopDecoding = StopDecoding;
                Invoke(stopDecoding);
            }
        }

        #endregion

        #region Принудительная остановка декодирования.
        private void ForcedStopDecoding()
        {
            _cancellationTokenSource.Cancel();
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
        private void CountWorkingTime(ref TimeSpan fullWorkingTime)
        {
            DateTime finishWorkingTime = DateTime.Now;
            TimeSpan deltaWorkingTime = finishWorkingTime - _startWorkingTimeOnboard;
            fullWorkingTime += deltaWorkingTime;
        }

        #endregion

        #region Запись в лог файл времени наработки.
        private void WriteToLogWorkingTime(string fileName, string time)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8, 65536))
            {
                sw.WriteLine(time);
            }
        }

        #endregion

        #region Чтение из лог файла времени наработки.
        private void ReadFromLogWorkingTime(string fileName, out TimeSpan fullWorkingTime, ToolStripStatusLabel WorkingTimeLabel)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                fullWorkingTime = TimeSpan.Parse(sr.ReadLine());
                WorkingTimeLabel.Text = $"{(long)fullWorkingTime.TotalHours}:{fullWorkingTime.Minutes.ToString("D2")}:{fullWorkingTime.Seconds}";              
            }
        }

        #endregion
    }
}

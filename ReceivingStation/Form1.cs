using System;
using System.IO;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReceivingStation.Decode;
using ReceivingStation.Other;
using ReceivingStation.Properties;
using System.Text;
using System.Collections.Generic;

namespace ReceivingStation
{
    public partial class MainForm : Form
    {
        private Decode.Decode _decode;
        private string _fileName;
        private bool _remoteModeFlag;
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private PictureBox[] _channels = new PictureBox[6];
        private PictureBox[] _allChannels = new PictureBox[6];
        private DateTime _startWorkingTime;

        private List<DirectBitmap>[] listImages = new List<DirectBitmap>[6];
        private DirectBitmap[] listItem = new DirectBitmap[6];
        private DirectBitmap k;
        Graphics g;

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
            slWorkingTime.Text = $"{(long)Settings.Default.WorkingTime.TotalHours}:{Settings.Default.WorkingTime.Minutes}:{Settings.Default.WorkingTime.Seconds}";

            Decode.Decode.ThreadGuiUpdater = UpdateGui;
            Decode.Decode.ThreadStopDecoding = StopDecoding;
            Server.Server.ThreadChangeMode = ChangeMode;
            Server.Server.ThreadSetParameters = RemoteSetReceiveParameters;
            Server.Server.ThreadStartReceiving = RemoteStartReceiving;

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

            k = new DirectBitmap(pACChannel1.Width, pACChannel1.Height);
            pACChannel1.BackgroundImage = k.Bitmap;

            g = Graphics.FromImage(k.Bitmap);

            _startWorkingTime = DateTime.Now;

            timer1.Start();

            for (int i = 0; i < listImages.Length; i++)
            {
                listImages[i] = new List<DirectBitmap>();
            }

            var server = new Server.Server();
            Task.Run(() => server.StartServer());          
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {           
            CountWorkingTime();
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
            StartReceiving();
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
            slTime.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);            
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
                    WriteToLog("Дистанционное управление");
                    _remoteModeFlag = true;
                }
                else if (modeNumber == 1)
                {
                    // Местное управление
                    Enabled = true;
                    slMode.Text = "Местное управление";
                    WriteToLog("Местное управление");
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
                WriteToLog($"Установлены параметры: ФПЦ - {_fcp}, ПРД - {_prd}, Частота - {_freq}, Интерливинг - {_interliving}");
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
            WriteToLog($"Установлены параметры: ФПЦ - {_fcp}, ПРД - {_prd}, Частота - {_freq}, Интерливинг - {_interliving}");
        }

        #endregion

        #region Начать прием потока.
        public void StartReceiving()
        {
            if (!_remoteModeFlag)
            {
                LocalSetReceiveParameters();
            }

            WriteToLog("Запись потока начата");
            // Receiver receiver = new Receiver(_fcp, _prd, _freq, _interliving);
            // receiver.StartReceive();

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

        #region Начать декодирование.
        private void StartDecoding()
        {
            bool reedSoloFlag = rbRSYes.Checked;
            bool nrzFlag = rbNRZYes.Checked;

            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;

            _decode = new Decode.Decode(_fileName, reedSoloFlag, nrzFlag);
            Task.Run(() => _decode.StartDecode(_cancellationToken));

            btnStartDecode.Enabled = false;
            tsmiStartDecoding.Enabled = false;
            btnStopDecode.Enabled = true;
            tsmiStopDecoding.Enabled = true;
            gbDecodeParameters.Enabled = false;
        }

        #endregion

        #region Обновление GUI при декодировании.
        private void UpdateGui(uint counter, DirectBitmap[] images)
        {
            if (InvokeRequired == false)
            {
                lblFramesCounter.Text = counter.ToString();
                UpdateImages(images);
            }
            else
            {
                Decode.Decode.GuiUpdater update = UpdateGui;
                Invoke(update, counter, images);
            }
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

        #region Обновление изображений.
        private void UpdateImages(DirectBitmap[] images)
        {
            for (int i = 0; i < images.Length; i++)
            {
                _channels[i].Image = images[i].Bitmap;
                _allChannels[i].Image = images[i].Bitmap;
            }
            //g.DrawImage(images[0].Bitmap, 0, _decode.Yt);
            //pACChannel1.Refresh();
            //pACChannel1.Height = _decode.Yt;
        }

        #endregion

        #region Расчет времени наработки.
        private void CountWorkingTime()
        {
            DateTime finishWorkingTime = DateTime.Now;
            TimeSpan deltaWorkingTime = finishWorkingTime - _startWorkingTime;
            Settings.Default.WorkingTime += deltaWorkingTime;
            Settings.Default.Save();
        }

        #endregion

        #region Запись в лог файл.
        private void WriteToLog(string logMessage)
        {
            using (StreamWriter sw = new StreamWriter("log.txt", true, Encoding.UTF8, 65536))
            {
                sw.WriteLine($"{DateTime.Now} - {logMessage}");
            }
        }

        #endregion
    }
}

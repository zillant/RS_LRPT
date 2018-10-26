﻿using System;
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
using System.Drawing.Drawing2D;

namespace ReceivingStation
{
    public partial class MainForm : Form
    {
        private const int _timeForSaveWorkingTime = 1800; // Время для таймера, через которое нужно сохранять время наработки в файл (30 минут). 
        private const string _workingTimeKPAFileName = "working_time_kpa.txt";
        private const string _workingTimeSystemFileName = "working_time_system.txt";

        private Decode.Decode _decode;
        private string _fileName;
        private bool _remoteModeFlag;
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private DoubleBufferedPanel[] _channels = new DoubleBufferedPanel[6];
        private DoubleBufferedPanel[] _allChannels = new DoubleBufferedPanel[6];

        private DateTime _startWorkingTimeKPA; // Время начала работы КПА.
        private DateTime _startWorkingTimeOnboard; // Время начала работы борта.
        private TimeSpan _fullWorkingTimeKPA;
        private TimeSpan _fullWorkingTimeSystem;

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
            _startWorkingTimeKPA = DateTime.Now;

            try
            {
                ReadFromLogWorkingTime(_workingTimeKPAFileName, out _fullWorkingTimeKPA, slWorkingTimeKPA);
            }
            catch (Exception)
            {
                WriteToLogWorkingTime(_workingTimeKPAFileName, "0:0:0");
                ReadFromLogWorkingTime(_workingTimeKPAFileName, out _fullWorkingTimeKPA, slWorkingTimeKPA);
            }

            try
            {
                ReadFromLogWorkingTime(_workingTimeSystemFileName, out _fullWorkingTimeSystem, slWorkingTimeSystem);
            }
            catch (Exception)
            {
                WriteToLogWorkingTime(_workingTimeSystemFileName, "0:0:0");
                ReadFromLogWorkingTime(_workingTimeSystemFileName, out _fullWorkingTimeSystem, slWorkingTimeSystem);
            }

            Decode.Decode.ThreadUiUpdater = UpdateUi;
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

            _startWorkingTimeKPA = DateTime.Now;
            _counterForSaveWorkingTime = _timeForSaveWorkingTime;
            timer1.Start();

            _isReceivingStarting = false;
            var server = new Server.Server();
            Task.Run(() => server.StartServer());          
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {           
            CountWorkingTime(ref _fullWorkingTimeKPA);
            WriteToLogWorkingTime(_workingTimeKPAFileName, _fullWorkingTimeKPA.ToString());
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
            slTime.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            if (_counterForSaveWorkingTime > 0)
            {
                _counterForSaveWorkingTime = _counterForSaveWorkingTime - 1;
            }
            else
            {
                CountWorkingTime(ref _fullWorkingTimeKPA);
                WriteToLogWorkingTime(_workingTimeKPAFileName, _fullWorkingTimeKPA.ToString());
                if (_isReceivingStarting)
                {
                    CountWorkingTime(ref _fullWorkingTimeSystem);
                    WriteToLogWorkingTime(_workingTimeSystemFileName, _fullWorkingTimeSystem.ToString());
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
            CountWorkingTime(ref _fullWorkingTimeSystem);
            WriteToLogWorkingTime(_workingTimeSystemFileName, _fullWorkingTimeSystem.ToString());
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

        #region Обновление пользовательского интерфейса при декодировании.
        private void UpdateUi(uint counter, Bitmap[] images)
        {
            if (InvokeRequired == false)
            {
                lblFramesCounter.Text = counter.ToString();
                UpdateImages(images);            
            }
            else
            {
                Decode.Decode.UiUpdater updateUi = UpdateUi;
                Invoke(updateUi, counter, images);
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
        private void UpdateImages(Bitmap[] images)
        {         
            for (int i = 0; i < 6; i++)
            {
                _channels[i].BackgroundImage = images[i];
                _allChannels[i].BackgroundImage = images[i];
            }
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
            TimeSpan deltaWorkingTime = finishWorkingTime - _startWorkingTimeKPA;
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
                WorkingTimeLabel.Text = $"{(long)fullWorkingTime.TotalHours}:{fullWorkingTime.Minutes}:{fullWorkingTime.Seconds}";              
            }
        }

        #endregion
    }
}

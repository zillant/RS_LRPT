using MaterialSkin.Controls;
using ReceivingStation.Other;
using ReceivingStation.Properties;
using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReceivingStation.MessageBoxes;
using ReceivingStation.Server;
using System.IO;

namespace ReceivingStation
{
    public partial class FormSelfTest : MaterialForm
    {
        private Server.Server _server;
        private Thread _serverThread;
        private ClientForSelfTest _client;

        private Demodulator.Demodulating _receiver;
        private byte _freq;
        private byte _interliving;
        private byte _modulation;

        private int _errorsTkCount; // Для подсчета ТК с ошибками превышающими 15 на 1 байт ТК.

        bool[] flags = new bool[2];
        bool lockedlost = false;
        bool locked = false;

        private enum InputType
        {
            RTLSDR,
            WavFile
        }
        private InputType _inputType;
        private string _waveFile;
        private int count;
        private int PLLCount;
        private int PSPCount;

        private Thread _updateLock;

        public FormSelfTest()
        {
            InitializeComponent();
        }

        private void FormSelfTest_Load(object sender, EventArgs e)
        {
            GuiUpdater.SmoothLoadingForm(this);

            RobotoFont.AllocFont(rtbSelfTest, 11);

            UpdateLastDates();

            slTime.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            timer1.Start();

            _client = new ClientForSelfTest() { ThreadSafeWriteActions = WriteActions };

            _server = new Server.Server(true);

            _serverThread = new Thread(_server.StartServer) { IsBackground = true };
            _serverThread.Start();

            _inputType = InputType.WavFile;

        }

        private void FormSelfTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = FormDialogMessageBox.Show("Выход", "Вы уверены, что хотите закрыть программу?", Resources.door_exit_icon);

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void FormSelfTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            _server.StopThread = true;
            _serverThread.Join(100);

            Application.Exit();
        }

        private void FormSelfTest_KeyDown(object sender, KeyEventArgs e)
        {
            // Alt + P  
            if (e.Alt && e.KeyCode == Keys.P)
            {
                Settings.Default.lastSelfTestDate = "Не проводилась";
                Settings.Default.lastSelfTestServerDate = "Не проводилась";
                Settings.Default.Save();

                UpdateLastDates();
                e.SuppressKeyPress = true;
            }

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            slTime.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);

            if (_receiver != null)
            {
                flags = _receiver.UpdateDataGui();
                bool pspFinded = _receiver.PSPFinded;
                bool pllLocked = _receiver._carrierPhaseLocked;

                if (pllLocked) locked = true;
                if (!pllLocked) PLLCount++;
                if (!pspFinded) PSPCount++;
                if (pspFinded) count++;
                if (locked && !pllLocked) lockedlost = true;

                if (lockedlost || count == 10 || PLLCount == 30 || PSPCount == 30)
                {
                    count = 0;
                    PLLCount = 0;
                    PSPCount = 0;
                    if (_errorsTkCount > 0)
                    {
                        WriteActions("  Самопроверка прошла с ошибками\n\n", GuiUpdater.ErrorColor);
                    }
                    else if (PLLCount == 30)
                    {
                        WriteActions("  Отсутствует высокочастотный сигнал\n\n", GuiUpdater.ErrorColor);
                    }
                    else if (PSPCount == 30)
                    {
                        WriteActions("  Отсутствует синхромаркер\n\n", GuiUpdater.ErrorColor);
                    }
                    else
                    {
                        WriteActions("  Самопроверка прошла без ошибок\n\n", GuiUpdater.OkColor);
                    }

                    WriteActions("  Самопроверка завершена", Color.White);
                    LogFiles.WriteUserActions("Самопроверка завершена");

                    if (_receiver != null)
                    {
                        _receiver.StopDecoding();
                        _receiver = null;
                    }
                    lockedlost = false;
                    locked = false;                 
                }
            }
        }

        private void btnSelfTesting_Click(object sender, EventArgs e)
        {
            rtbSelfTest.Clear();
            pSelfTestSettings.Enabled = false;
            Settings.Default.lastSelfTestDate = DateTime.Now.ToString();
            Settings.Default.Save();
            UpdateLastDates();

            LogFiles.WriteUserActions("Начата самопроверка");
            WriteActions("  Начата самопроверка\n\n", Color.White);

            if (rbFreq1.Checked) _freq = 0x1;
            else if (rbFreq2.Checked) _freq = 0x2;
            if (rbInterlivingReceiveOn.Checked) _interliving = 0x1;
            else if (rbInterlivingReceiveOff.Checked) _interliving = 0x2;

            if (rbQpsk.Checked) _modulation = 0x1; // QPSK mod ON
            else _modulation = 0x2; // OQPSK mod off

            var isSelfTest = true;
            Decode.Decode _decode = new Decode.Decode() { ThreadSafeUpdateSelfTestData = UpdateSelfTestData };
            if (_receiver == null)  _receiver = new Demodulator.Demodulating(_freq, _interliving, _modulation, _decode);
            if (_inputType == InputType.RTLSDR)
            {
                uint freq;
                freq = _freq == 0x1 ? freq = 137100000 : freq = 137900000;
                _receiver.Dongle_Configuration(freq, 1024000, 15); // инициализируем свисток, в нем отсчеты записываются в поток
                _receiver.StartDecoding();
                _receiver.RecordStart(isSelfTest);
            }
            if (_inputType == InputType.WavFile)
            {
                try
                {
                    SelectWaveFile();
                    if (!File.Exists(_waveFile))
                    {
                        throw new ApplicationException("Не выбран файл");
                    }
                    _receiver.wav_samples(_waveFile, 2048, true);
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show(ex.Message);
                   
                }
            }

            pSelfTestSettings.Enabled = true;
        }

        private void SelectWaveFile()
        {
            if (opnDlg.ShowDialog() == DialogResult.OK)
            {
                _waveFile = opnDlg.FileName;
            }
        }

        private async void btnSelfTestingServer_Click(object sender, EventArgs e)
        {
            rtbSelfTest.Clear();
            pSelfTestSettings.Enabled = false;
            Settings.Default.lastSelfTestServerDate = DateTime.Now.ToString();
            Settings.Default.Save();

            LogFiles.WriteUserActions("Начата самопроверка сервера");
            WriteActions("  Клиент подключен\n\n", Color.White);
            await Task.Run(() => { _client.StartClient(rbSequentialSending.Checked); });
            btnSelfTestingServer.Enabled = true;
            WriteActions("  Тест завершен\n", Color.White);
            WriteActions("  Клиент отключен", Color.White);
            LogFiles.WriteUserActions("Самопроверка сервера завершена");

            pSelfTestSettings.Enabled = true;
            UpdateLastDates();
        }

        private void WriteActions(string msg, Color color)
        {
            rtbSelfTest.Invoke(new Action(() => { rtbSelfTest.AppendText(msg, color); }));
        }

        private void UpdateLastDates()
        {
            lblSelfTestingDate.Text = Settings.Default.lastSelfTestDate;
            lblSelfTestingServerDate.Text = Settings.Default.lastSelfTestServerDate;
        }

        private void UpdateSelfTestData(uint tkCount, int errorsTkCount)
        {
            _errorsTkCount = errorsTkCount;

            if (InvokeRequired)
            {
               Invoke(new Action(() => rtbSelfTest.Text = $"  Начата самопроверка\n\n  Кол-во кадров: {tkCount}\n  Кол-во кадров с ошибками: {_errorsTkCount}\n\n"));
            }
        }
    }
}

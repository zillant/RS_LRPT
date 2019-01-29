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
            // Alt + L  
            if (e.Alt && e.KeyCode == Keys.L)
            {
                Settings.Default.lastSelfTestDate = "Не проводилась";
                Settings.Default.lastSelfTestServerDate = "Не проводилась";
                Settings.Default.Save();

                UpdateLastDates();
                e.SuppressKeyPress = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            slTime.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            if (_receiver != null)   flags = _receiver.UpdateDataGui();
        }

        private void btnSelfTesting_Click(object sender, EventArgs e)
        {
            rtbSelfTest.Clear();
            pSelfTestSettings.Enabled = false;
            Settings.Default.lastSelfTestDate = DateTime.Now.ToString();
            Settings.Default.Save();


            LogFiles.WriteUserActions("Начата самопроверка");
            WriteActions("  Начата самопроверка\n\n", Color.White);

            if (rbFreq1.Checked) _freq = 0x1;
            else if (rbFreq2.Checked) _freq = 0x2;
            if (rbInterlivingReceiveOn.Checked) _interliving = 0x1;
            else if (rbInterlivingReceiveOff.Checked) _interliving = 0x2;
            UpdateLastDates();
            _modulation = 0x1; // QPSK mod ON
            //_modulation = 0x2; // OQPSK mod off

            // Тут создаем приемник и старт декод вызываем там. параметры конструктора декода не нужны. 
            // Пока просто тест с готовым файлом.
            var isSelfTest = true;
            Decode.Decode _decode = new Decode.Decode() { ThreadSafeUpdateSelfTestData = UpdateSelfTestData };
            if (_receiver == null)  _receiver = new Demodulator.Demodulating(_freq, _interliving, _modulation, _decode);
            _receiver.Dongle_Configuration(1024000); // инициализируем свисток, в нем отсчеты записываются в поток
            _receiver.StartDecoding();
            _receiver.RecordStart(isSelfTest);

            pSelfTestSettings.Enabled = true;

            // Вызвать в приемнике. задать нужную сигнатуру в классе дкодера или использовать готовую из режима "Прием".
            // await Task.Run(() => _decode.StartDecode()); 
            // PSP Finded
            //Task.Run(() => UpdateLock());
            _updateLock = new Thread(UpdateLock);
            _updateLock.Start();
        }
       
        private void UpdateLock()
        {
            while (true)
            {
                flags = _receiver.UpdateDataGui();
                if (flags[1]) locked = true;
                if (locked && !flags[1]) lockedlost = true;

                if (lockedlost)
                {
                    if (_errorsTkCount > 0)
                    {
                        WriteActions("  Самопроверка прошла с ошибками\n\n", GuiUpdater.ErrorColor);
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
                    
                    return;

                }
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

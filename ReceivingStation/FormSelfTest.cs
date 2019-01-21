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

        private int _errorsCount; // Для подсчета ошибок самопроверки и выдачи результата.

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
        }

        private void btnSelfTesting_Click(object sender, EventArgs e)
        {
            rtbSelfTest.Clear();
            pSelfTestSettings.Enabled = false;
            Settings.Default.lastSelfTestDate = DateTime.Now.ToString();
            Settings.Default.Save();

            LogFiles.WriteUserActions("Начата самопроверка");
            WriteActions("  Начата самопроверка\n\n", Color.White);

            // Тут создаем приемник и старт декод вызываем там. параметры конструктора декода не нужны. 
            // Пока просто тест с готовым файлом.
            Decode.Decode _decode = new Decode.Decode(_fileName, false) { ThreadSafeUpdateSelfTestData = UpdateSelfTestData };
            _decode.StartDecode(true); 

            if (_errorsCount < 10)
            {
                WriteActions("  Кол-во ошибок в пределах нормы\n\n", GuiUpdater.OkColor);
            }
            else
            {
                WriteActions("  Слишком много ошибок\n\n", GuiUpdater.ErrorColor);
            }

            WriteActions("  Самопроверка завершена", Color.White);
            LogFiles.WriteUserActions("Самопроверка завершена");

            pSelfTestSettings.Enabled = true;
            UpdateLastDates();
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

        private void UpdateSelfTestData(uint tkCount, int errorsCount)
        {
            _errorsCount = errorsCount;

            rtbSelfTest.Text = "";
            WriteActions("  Начата самопроверка\n\n", Color.White);       
            WriteActions($"  Кол-во кадров: {tkCount}\n  Кол-во ошибок: {_errorsCount}\n\n", Color.White);            
        }

        private string _fileName;
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Title = "Выбор файла телеметрии";
                openFileDialog1.Filter = "Telemetry files (*.dat)|*.dat";
                openFileDialog1.FilterIndex = 1;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    _fileName = openFileDialog1.FileName;
                }
            }
        }
    }
}

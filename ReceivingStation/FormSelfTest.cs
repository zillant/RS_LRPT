using MaterialSkin.Controls;
using ReceivingStation.Other;
using ReceivingStation.Properties;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReceivingStation
{
    public partial class FormSelfTest : MaterialForm
    {
        private bool _isReceivingStarting;

        private Server _server;
        private Thread _serverThread;
        private ClientForSelfTest _client;

        public FormSelfTest()
        {
            InitializeComponent();
        }

        private void FormSelfTest_Load(object sender, EventArgs e)
        {
            GuiUpdater.SmoothLoadingForm(this);

            Server.remoteModeFlag = false;
            _isReceivingStarting = false;

            slTime.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            timer1.Start();

            _client = new ClientForSelfTest();

            _server = new Server()
            {
                ThreadSafeChangeMode = ChangeMode,
                ThreadSafeSetReceiveParameters = SetReceiveParameters,
                ThreadSafeStartStopReceiving = StartStopReceiving
            };

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
            _server.stopThread = true;
            _serverThread.Join(100);

            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            slTime.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
        }

        private async void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            materialRaisedButton1.Enabled = false;
            await Task.Run(() => { _client.StartClient(); });
            materialRaisedButton1.Enabled = true;
        }

        #region Начать прием потока.
        public void StartStopReceiving()
        {
            if (!_isReceivingStarting)
            {
                _isReceivingStarting = true;
                lblStartReceive.SetPropertyThreadSafe(() => lblStartReceive.Text, "OK");
            }
            else
            {
                _isReceivingStarting = false;
                lblStopReceive.SetPropertyThreadSafe(() => lblStopReceive.Text, "OK");
            }          
        }

        #endregion

        #region Смена режима управления.
        private void ChangeMode(byte modeNumber)
        {
            if (modeNumber == 0)
            {
                // Дистанционное управление
                lblRemoteMode.SetPropertyThreadSafe(() => lblRemoteMode.Text, "OK");
            }
            else if (modeNumber == 1)
            {
                // Местное управление
                lblLocalMode.SetPropertyThreadSafe(() => lblLocalMode.Text, "OK");               
            }
        }

        #endregion

        #region Установка параметров записи потока в дистанционном режиме управления.
        private void SetReceiveParameters(byte fcp, byte prd, byte freq, byte interliving)
        {
            lblSetParameters.SetPropertyThreadSafe(() => lblSetParameters.Text, $"ФЦП - {fcp}, ПРД - {prd}, Частота - {freq}, Интерливинг - {interliving} ");
        }

        #endregion
    }
}

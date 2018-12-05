using MaterialSkin.Controls;
using ReceivingStation.Other;
using ReceivingStation.Properties;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace ReceivingStation
{
    public partial class FormSelfTest : MaterialForm
    {
        public FormSelfTest()
        {
            InitializeComponent();
        }

        private void FormSelfTest_Load(object sender, EventArgs e)
        {
            GuiUpdater.SmoothLoadingForm(this);

            slTime.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            timer1.Start();
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
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            slTime.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}

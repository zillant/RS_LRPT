using MaterialSkin.Controls;
using ReceivingStation.Other;
using System;
using System.Windows.Forms;
using ReceivingStation.MessageBoxes;
using ReceivingStation.Properties;

namespace ReceivingStation
{
    public partial class FormMenu : MaterialForm
    {
        public FormMenu()
        {
            InitializeComponent();
            GuiUpdater.LoadFont();
            GuiUpdater.SmoothLoadingForm(this);
            FilesDirectory.CreateApplicationDirectory();
        }

        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = FormDialogMessageBox.Show("Выход", "Вы уверены, что хотите закрыть программу?", Resources.door_exit_icon);

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void btnSelfTest_Click(object sender, EventArgs e)
        {
            GuiUpdater.SmoothHidingForm(this);

            var formSelfTest = new FormSelfTest();
            formSelfTest.Show();

            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            GuiUpdater.SmoothHidingForm(this);

            var formReceive = new FormReceive();
            formReceive.Show();

            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            GuiUpdater.SmoothHidingForm(this);

            var formDecode = new FormDecode();
            formDecode.Show();

            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
        }
    }
}

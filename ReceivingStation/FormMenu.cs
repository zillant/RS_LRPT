using MaterialSkin.Controls;
using ReceivingStation.Other;
using System;
using System.Windows.Forms;

namespace ReceivingStation
{
    public partial class FormMenu : MaterialForm
    {
        public FormMenu()
        {
            InitializeComponent();
            GuiUpdater.SmoothLoadingForm(this);
        }

        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = FormCloseMessageBox.Show();

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
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

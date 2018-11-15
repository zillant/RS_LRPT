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

        private void btnReceive_Click(object sender, EventArgs e)
        {
            GuiUpdater.SmoothHidingForm(this);
            var formReceive = new FormReceive();
            formReceive.Show();
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            GuiUpdater.SmoothHidingForm(this);
            var formDecode = new FormDecode();
            formDecode.Show();
        }     
    }
}

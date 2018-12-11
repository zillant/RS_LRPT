using MaterialSkin.Controls;
using ReceivingStation.Other;
using System;

namespace ReceivingStation
{
    public partial class FormModeSettings : MaterialForm
    {
        public delegate void ChangeModeDelegate(byte modeNumber);
        public ChangeModeDelegate ChangeMode;

        public FormModeSettings()
        {
            InitializeComponent();

            lblConnection.Text = Server.remoteModeFlag == false ? 
                "Режим: Местное управление" : "Режим: Дистанционное управление";
        }

        private void btnServerSettings_Click(object sender, EventArgs e)
        {
            using (FormServerSettings serverSettingsForm = new FormServerSettings())
            {               
                serverSettingsForm.ShowDialog();
            }          
        }

        private void btnChangeLocalMode_Click(object sender, EventArgs e)
        {
            if (Server.remoteModeFlag == false)
            {             
                lblConnection.ForeColor = GuiUpdater.errorColor; 
            }
            else
            {
                ChangeMode(1);
                Close();
            }

        }
    }
}

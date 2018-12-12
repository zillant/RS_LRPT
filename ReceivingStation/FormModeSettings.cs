using MaterialSkin.Controls;
using ReceivingStation.Other;
using System;
using ReceivingStation.Properties;

namespace ReceivingStation
{
    public partial class FormModeSettings : MaterialForm
    {
        public delegate void ChangeModeDelegate(byte modeNumber);
        public ChangeModeDelegate ChangeMode;

        public FormModeSettings()
        {
            InitializeComponent();

            lblConnection.Text = Server.Server.RemoteModeFlag == false ?
                $"Режим: {Resources.LocalControlString}" : $"Режим: {Resources.RemoteControlString}";
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
            if (Server.Server.RemoteModeFlag == false)
            {             
                lblConnection.ForeColor = GuiUpdater.ErrorColor; 
            }
            else
            {
                Server.Server.RemoteModeFlag = false;
                ChangeMode(1);
                Close();
            }

        }
    }
}

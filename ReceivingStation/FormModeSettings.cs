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

            CheckMode();           
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
                CheckMode();
            }
        }

        private void CheckMode()
        {
            if(Server.Server.RemoteModeFlag)
            {
                btnServerSettings.SetPropertyThreadSafe(() => btnServerSettings.Enabled, false);
                lblConnection.Text = $"Режим: {Resources.RemoteControlString}";
            }
            else
            {
                btnServerSettings.SetPropertyThreadSafe(() => btnServerSettings.Enabled, true);
                lblConnection.Text = $"Режим: {Resources.LocalControlString}";
            }
        }
    }
}

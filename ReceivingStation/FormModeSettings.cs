using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Net;

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
                lblConnection.ForeColor = Color.FromArgb(222, 211, 47, 47); 
            }
            else
            {
                ChangeMode(1);
                Close();
            }

        }
    }
}

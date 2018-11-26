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

        private FormReceive _mainForm;

        public FormModeSettings(FormReceive mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;

            lblConnection.Text = _mainForm.remoteModeFlag == false ? 
                "Режим: Местное управление" : "Режим: Дистанционное управление";
        }

        private void btnServerSettings_Click(object sender, EventArgs e)
        {
            Close();
            using (FormServerSettings serverSettingsForm = new FormServerSettings())
            {               
                serverSettingsForm.ShowDialog();
            }
           
        }

        private void btnChangeLocalMode_Click(object sender, EventArgs e)
        {
            if (_mainForm.remoteModeFlag == false)
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

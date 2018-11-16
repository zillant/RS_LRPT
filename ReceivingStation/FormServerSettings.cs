using System;
using System.Windows.Forms;
using MaterialSkin.Controls;
using ReceivingStation.MessageBoxes;
using ReceivingStation.Properties;

namespace ReceivingStation
{
    public partial class FormServerSettings : MaterialForm
    {
        const string DefaultIpAddress = "192.168.1.1";

        public FormServerSettings()
        {
            InitializeComponent();
            SetIpAddress(Settings.Default.ipAddressIVK);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string message = "Изменения вступят в силу после перезапуска программы.";
            string caption = "Внимание";
            
            if (GetIpAddress() != Settings.Default.ipAddressIVK)
            {
                Settings.Default.ipAddressIVK = GetIpAddress();
                Settings.Default.Save();

                FormInformationMessageBox.Show(caption, message);
            }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {           
            SetIpAddress(DefaultIpAddress);
        }

        private string GetIpAddress()
        {
            return $"{tbIP1.Text}.{tbIP2.Text}.{tbIP3.Text}.{tbIP4.Text}";
        }

        private void SetIpAddress(string ipAddress)
        {
            string[] ip = ipAddress.Split('.');

            tbIP1.Text = ip[0];
            tbIP2.Text = ip[1];
            tbIP3.Text = ip[2];
            tbIP4.Text = ip[3];           
        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!char.IsDigit(number) && number != 8) // Цифры и клавиша BackSpace.
            {
                e.Handled = true;
            }
        }
    }
}

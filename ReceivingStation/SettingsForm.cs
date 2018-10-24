using System;
using System.Windows.Forms;
using ReceivingStation.Properties;

namespace ReceivingStation
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            SetIpAddress(Settings.Default.ipAddressIVK);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string message = "Изменения вступят в силу после перезапуска программы.";
            string caption = "Перезапустить программу?";
            
            if (GetIpAddress() != Settings.Default.ipAddressIVK)
            {
                Settings.Default.ipAddressIVK = GetIpAddress();
                Settings.Default.Save();

                result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Restart();
                }

                Close();
            }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            string defaultIpAddress = "192.168.1.1";

            SetIpAddress(defaultIpAddress);
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

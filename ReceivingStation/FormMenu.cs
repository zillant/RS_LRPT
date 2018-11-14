using System;
using System.Windows.Forms;

namespace ReceivingStation
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            Hide();

            var formReceive = new FormReceive();
            formReceive.Show();
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            Hide();

            var formDecode = new FormDecode();
            formDecode.Show();
        }
    }
}

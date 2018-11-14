using System;
using System.Windows.Forms;

namespace ReceivingStation
{
    public partial class FormMenu : Form
    {
        FormReceive form;

        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            Hide();
            form = new FormReceive();
            form.Show();
        }
    }
}

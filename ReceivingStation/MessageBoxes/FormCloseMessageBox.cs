using System;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace ReceivingStation
{
    public partial class FormCloseMessageBox : MaterialForm
    {
        private static FormCloseMessageBox _formCloseMessageBox;
        private static DialogResult _result = DialogResult.No;

        public FormCloseMessageBox()
        {
            InitializeComponent();
        }

        public static DialogResult Show()
        {
            _formCloseMessageBox = new FormCloseMessageBox();
            _formCloseMessageBox.ShowDialog();

            return _result;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            _result = DialogResult.Yes;
            _formCloseMessageBox.Close();
        }
    }
}

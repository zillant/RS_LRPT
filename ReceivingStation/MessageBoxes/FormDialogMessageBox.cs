using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace ReceivingStation
{
    public partial class FormDialogMessageBox : MaterialForm
    {
        private static FormDialogMessageBox _formDialogMessageBox;
        private static DialogResult _result = DialogResult.No;

        public FormDialogMessageBox()
        {
            InitializeComponent();
        }

        public static DialogResult Show(string title, string text, Bitmap pictures)
        {
            _formDialogMessageBox = new FormDialogMessageBox();
            _formDialogMessageBox.Text = title;
            _formDialogMessageBox.lblMessage.Text = text;
            _formDialogMessageBox.pbPicture.Image = pictures;
            _formDialogMessageBox.ShowDialog();

            return _result;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {          
            _result = DialogResult.Yes;
            _formDialogMessageBox.Close();
        }
    }
}

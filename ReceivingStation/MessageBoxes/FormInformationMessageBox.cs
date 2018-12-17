using MaterialSkin.Controls;
using System.Drawing;

namespace ReceivingStation.MessageBoxes
{
    public partial class FormInformationMessageBox : MaterialForm
    {
        private static FormInformationMessageBox _formInformationMessageBox;

        public FormInformationMessageBox()
        {
            InitializeComponent();
        }

        public static void Show(string title, string text, Bitmap image)
        {
            _formInformationMessageBox = new FormInformationMessageBox
            {
                Text = title,
                lblInfo = { Text = text },
                pbImage = { Image = image }
            };
            _formInformationMessageBox.ShowDialog();
        }
    }
}

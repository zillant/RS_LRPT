using MaterialSkin.Controls;

namespace ReceivingStation.MessageBoxes
{
    public partial class FormInformationMessageBox : MaterialForm
    {
        private static FormInformationMessageBox _formInformationMessageBox;

        public FormInformationMessageBox()
        {
            InitializeComponent();
        }

        public static void Show(string title, string text)
        {
            _formInformationMessageBox = new FormInformationMessageBox
            {
                Text = title,
                lblInfo = {Text = text}
            };
            _formInformationMessageBox.ShowDialog();
        }
    }
}

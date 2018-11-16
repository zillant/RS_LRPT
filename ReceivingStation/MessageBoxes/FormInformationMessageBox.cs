using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            _formInformationMessageBox = new FormInformationMessageBox();
            _formInformationMessageBox.Text = title;
            _formInformationMessageBox.lblInfo.Text = text;
            _formInformationMessageBox.ShowDialog();
        }
    }
}

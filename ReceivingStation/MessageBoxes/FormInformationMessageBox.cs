using MaterialSkin.Controls;
using ReceivingStation.Other;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ReceivingStation.MessageBoxes
{
    public partial class FormInformationMessageBox : MaterialForm
    {
        private static FormInformationMessageBox _formInformationMessageBox;
        private static string _catalogPath;

        public FormInformationMessageBox()
        {
            InitializeComponent();
        }

        public static void Show(string title, string text, Bitmap image, string text2="", string linkName="", string catalogPath="")
        {         
            _formInformationMessageBox = new FormInformationMessageBox
            {
                Text = title,
                lblInfo = { Text = text },
                lblInfo2 = { Text = text2 },
                llPath = { Text = linkName },
                pbImage = { Image = image }
            };

            _catalogPath = catalogPath;

            RobotoFont.AllocFont(_formInformationMessageBox.llPath, 11);
            _formInformationMessageBox.llPath.LinkClicked += LinkClicked;

            _formInformationMessageBox.ShowDialog();
        }

        private static void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("explorer.exe", " /open, " + Path.GetDirectoryName(_catalogPath)));
        }
    }
}


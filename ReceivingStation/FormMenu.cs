using ReceivingStation.Other;
using System;
using System.Windows.Forms;

namespace ReceivingStation
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            GuiUpdater.SmoothLoadingForm(this);
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            GuiUpdater.SmoothHidingForm(this);
            var formReceive = new FormReceive();
            formReceive.Show();
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            GuiUpdater.SmoothHidingForm(this);
            var formDecode = new FormDecode();
            formDecode.Show();
        }     

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Перетаскивание формы за верхний край.
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lblTitle.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        private void FormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        #endregion
    }
}

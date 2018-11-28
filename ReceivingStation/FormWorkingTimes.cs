using MaterialSkin.Controls;
using ReceivingStation.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace ReceivingStation
{
    public partial class FormWorkingTimes : MaterialForm
    {
        public FormWorkingTimes()
        {
            InitializeComponent();
        }

        private void FormWorkingTimes_Load(object sender, EventArgs e)
        {
            DisplayWorkinTime(lblFCPMain, FormReceive.MainFcpWorkingTime);
            DisplayWorkinTime(lblFCPReserve, FormReceive.ReserveFcpWorkingTime);
            DisplayWorkinTime(lblPRDMain, FormReceive.MainPrdWorkingTime);
            DisplayWorkinTime(lblPRDReserve, FormReceive.ReservePrdWorkingTime);            
        }

        private void DisplayWorkinTime(MaterialLabel label, TimeSpan workingTime)
        {
            label.Text = $"{(long)workingTime.TotalHours}";
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            var result = FormDialogMessageBox.Show("Очистка счетчика", "Вы уверены, что хотите очистить счетчик?", Resources.clear_icon);

            if (result == DialogResult.Yes)
            {
                File.Delete(Settings.Default.OnboardWorkingTimeFileName);

                FormReceive.MainFcpWorkingTime = TimeSpan.Zero;
                FormReceive.ReserveFcpWorkingTime = TimeSpan.Zero;
                FormReceive.MainPrdWorkingTime = TimeSpan.Zero;
                FormReceive.ReservePrdWorkingTime = TimeSpan.Zero;
                FormReceive.FullWorkingTime = TimeSpan.Zero;

                DisplayWorkinTime(lblFCPMain, FormReceive.MainFcpWorkingTime);
                DisplayWorkinTime(lblFCPReserve, FormReceive.ReserveFcpWorkingTime);
                DisplayWorkinTime(lblPRDMain, FormReceive.MainPrdWorkingTime);
                DisplayWorkinTime(lblPRDReserve, FormReceive.ReservePrdWorkingTime);
            }
        }
    }  
}

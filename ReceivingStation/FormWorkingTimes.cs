using MaterialSkin.Controls;
using ReceivingStation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReceivingStation
{
    public partial class FormWorkingTimes : MaterialForm
    {
        private TimeSpan _mainFCPWorkingTime;
        private TimeSpan _reserveFCPWorkingTime;
        private TimeSpan _mainPRDWorkingTime;
        private TimeSpan _reservePRDWorkingTime;
        private TimeSpan _fullWorkingTime; // Общее время работы системы.

        public FormWorkingTimes()
        {
            InitializeComponent();
        }

        private void ReadFromLogWorkingTime(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                _mainFCPWorkingTime = TimeSpan.Parse(sr.ReadLine());
                _reserveFCPWorkingTime = TimeSpan.Parse(sr.ReadLine());
                _mainPRDWorkingTime = TimeSpan.Parse(sr.ReadLine());
                _reservePRDWorkingTime = TimeSpan.Parse(sr.ReadLine());
                _fullWorkingTime = TimeSpan.Parse(sr.ReadLine());
            }
        }

        private void FormWorkingTimes_Load(object sender, EventArgs e)
        {
            ReadFromLogWorkingTime(Settings.Default.OnboardWorkingTimeFileName);
            lblFCPMain.Text = $"{(long)_mainFCPWorkingTime.TotalHours}:{_mainFCPWorkingTime.Minutes.ToString("D2")}:{_mainFCPWorkingTime.Seconds.ToString("D2")}";
            lblFCPReserve.Text = $"{(long)_reserveFCPWorkingTime.TotalHours}:{_reserveFCPWorkingTime.Minutes.ToString("D2")}:{_reserveFCPWorkingTime.Seconds.ToString("D2")}";
            lblPRDMain.Text = $"{(long)_mainPRDWorkingTime.TotalHours}:{_mainPRDWorkingTime.Minutes.ToString("D2")}:{_mainPRDWorkingTime.Seconds.ToString("D2")}";
            lblPRDReserve.Text = $"{(long)_reservePRDWorkingTime.TotalHours}:{_reservePRDWorkingTime.Minutes.ToString("D2")}:{_reservePRDWorkingTime.Seconds.ToString("D2")}";
            lblFull.Text = $"{(long)_fullWorkingTime.TotalHours}:{_fullWorkingTime.Minutes.ToString("D2")}:{_fullWorkingTime.Seconds.ToString("D2")}";
        }
    }  
}

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

        private void FormWorkingTimes_Load(object sender, EventArgs e)
        {
            ReadFromLogWorkingTime(Settings.Default.OnboardWorkingTimeFileName);
            DisplayWorkinTime(lblFCPMain, _mainFCPWorkingTime);
            DisplayWorkinTime(lblFCPReserve, _reserveFCPWorkingTime);
            DisplayWorkinTime(lblPRDMain, _mainPRDWorkingTime);
            DisplayWorkinTime(lblPRDReserve, _reservePRDWorkingTime);
            DisplayWorkinTime(lblFull, _fullWorkingTime);            
        }

        private void DisplayWorkinTime(MaterialLabel label, TimeSpan workingTime)
        {
            label.Text = $"{(long)workingTime.TotalHours}:{workingTime.Minutes.ToString("D2")}:{workingTime.Seconds.ToString("D2")}.{workingTime.Milliseconds.ToString("D2")}";
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
    }  
}

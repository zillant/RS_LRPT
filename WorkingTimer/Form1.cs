using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WorkingTimer.Properties;

namespace WorkingTimer
{
    public partial class Form1 : Form
    {
        /* * Счетчик времени наработки КПА. * */

        // Для получения шрифта из ресурсов.
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);
        private FontFamily _ff;
        private Font _font;

        private const int _savingTime = 10; // Время через которое сохраняется время наработки (10 сек).
        
        private DateTime _startWorkingTime; // Время начала работы КПА.
        private TimeSpan _timerTimeSpan; // Дубликат timeSpan для вывода в таймере (Чтоб лишний раз не трогать timeSpan из параметров).
        private int _counterForSaveWorkingTime; // Счетчик для отсчета времени до сохранения времени наработки. 
        public bool _allowClosing; // Для закрытия приложения только через иконку в трее.

        public Form1()
        {
            InitializeComponent();

            ShowInTaskbar = false;
            notifyIcon.ContextMenuStrip = contextMenuStrip1;

            _startWorkingTime = DateTime.Now;
            _counterForSaveWorkingTime = _savingTime;
            _timerTimeSpan = Settings.Default.WorkingTime.Duration();

            lblTime.Text = $"{(long)_timerTimeSpan.TotalHours}:{_timerTimeSpan.Minutes}";
            lblSecond.Text = $"{_timerTimeSpan.Seconds}";

            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFont();
            AllocFont(_font, lblTime, 30);
            AllocFont(_font, lblSecond, 30);
        }

        void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (Visible)
                Hide();
            else
                Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = $"{(long)_timerTimeSpan.TotalHours}:{_timerTimeSpan.Minutes}";
            lblSecond.Text = $"{_timerTimeSpan.Seconds}";

            _timerTimeSpan += TimeSpan.FromSeconds(1);
            if (_counterForSaveWorkingTime > 0)
            {
                _counterForSaveWorkingTime -= 1;
            }
            else
            {
                CountWorkingTime();
                _counterForSaveWorkingTime = _savingTime;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_allowClosing)
            {
                e.Cancel = true;                
                Hide();
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            _allowClosing = true;
            Application.Exit();
        }

        #region Расчет времени наработки.
        private void CountWorkingTime()
        {
            DateTime finishWorkingTime = DateTime.Now;
            TimeSpan deltaWorkingTime = finishWorkingTime - _startWorkingTime;
            Settings.Default.WorkingTime += deltaWorkingTime;
            Settings.Default.Save();
        }

        #endregion

        private void LoadFont()
        {
            byte[] fontArray = Resources.digital_7_regular;
            int dataLength = Resources.digital_7_regular.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;

            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddMemoryFont(ptrData, dataLength);
            Marshal.FreeCoTaskMem(ptrData);
            _ff = pfc.Families[0];
            _font = new Font(_ff, 15f, FontStyle.Bold);
        }

        private void AllocFont(Font f, Control c, float size)
        {
            FontStyle fontStyle = FontStyle.Regular;
            c.Font = new Font(_ff, size, fontStyle);

        }


    }
}

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
        private TimeSpan _timerTimeSpan; // Дубликат timeSpan для вывода в таймере (Чтобы лишний раз не трогать timeSpan из параметров).
        private int _counterForSaveWorkingTime; // Счетчик для отсчета времени до сохранения времени наработки. 
        public bool _allowClosing; // Для закрытия приложения только через иконку в трее. 
                                   // На данный момент кнопка закрытия программы на форме (Х) убрана.

        private Point _windowPosition; // Для перемещения формы.

        public Form1()
        {
            InitializeComponent();

            ShowInTaskbar = false;
            notifyIcon.ContextMenuStrip = contextMenuStrip1;

            InitTimerData();                          
            _timerTimeSpan = Settings.Default.WorkingTime.Duration();

            Location = Settings.Default.WindowPosition;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFont();
            AllocFont(_font, lblTime, 70);
            AllocFont(_font, lblSecond, 35);
          
            lblTime.Text = $"{(long)_timerTimeSpan.TotalHours}:{_timerTimeSpan.Minutes.ToString("D2")}";
            lblSecond.Text = $"{_timerTimeSpan.Seconds}";

            lblSecond.Location = new Point(lblTime.Location.X + lblTime.Width - 5, lblTime.Location.Y + lblTime.Height / 4);
            saveTimer.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.J)
            {          
                e.SuppressKeyPress = true;
                Settings.Default.Reset();
                Settings.Default.Save();
                _allowClosing = true;
                Application.Restart();
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

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            Move1(e);
        }

        private void lblTitle_MouseMove(object sender, MouseEventArgs e)
        {
            Move2(e);
        }

        private void lblTime_MouseDown(object sender, MouseEventArgs e)
        {
            Move1(e);
        }

        private void lblTime_MouseMove(object sender, MouseEventArgs e)
        {
            Move2(e);
        }

        private void lblSecond_MouseDown(object sender, MouseEventArgs e)
        {
            Move1(e);
        }

        private void lblSecond_MouseMove(object sender, MouseEventArgs e)
        {
            Move2(e);
        }

        private void saveTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = $"{(long)_timerTimeSpan.TotalHours}:{_timerTimeSpan.Minutes.ToString("D2")}";
            lblSecond.Text = $"{_timerTimeSpan.Seconds}";
            lblSecond.Location = new Point(lblTime.Location.X + lblTime.Width - 5, lblTime.Location.Y + lblTime.Height / 4);

            _counterForSaveWorkingTime -= 1;
            _timerTimeSpan += TimeSpan.FromSeconds(1);

            if (_counterForSaveWorkingTime == 0)
            {
                CountWorkingTime();
                InitTimerData();
            }

            if (Location != Settings.Default.WindowPosition)
            {
                Settings.Default.WindowPosition = Location;
                Settings.Default.Save();
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (Visible)
                Hide();
            else
                Show();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            _allowClosing = true;
            Application.Exit();
        }

        #region Инициализация данных для таймера.
        private void InitTimerData()
        {
            _startWorkingTime = DateTime.Now;
            _counterForSaveWorkingTime = _savingTime;
        }

        #endregion
    
        #region Расчет времени наработки.
        private void CountWorkingTime()
        {
            DateTime finishWorkingTime = DateTime.Now;
            TimeSpan deltaWorkingTime = finishWorkingTime - _startWorkingTime;
            Settings.Default.WorkingTime += deltaWorkingTime;
            Settings.Default.Save();
        }

        #endregion

        #region Загрузка шрифта из ресурсов.
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

        #endregion

        #region Передача настроек шрифта контролу.
        private void AllocFont(Font f, Control c, float size)
        {
            FontStyle fontStyle = FontStyle.Regular;
            c.Font = new Font(_ff, size, fontStyle);

        }

        #endregion

        #region Перемещение формы.
        private void Move1(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _windowPosition = MousePosition;
            }
        }

        private void Move2(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int posX = MousePosition.X - _windowPosition.X;
                int posY = MousePosition.Y - _windowPosition.Y;
                Point loc = new Point(Location.X + posX, Location.Y + posY);
                Location = loc;
                _windowPosition = MousePosition;
            }
        }

        #endregion
    }
}

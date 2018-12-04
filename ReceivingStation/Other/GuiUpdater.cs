using ReceivingStation.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ReceivingStation.Other
{
    internal static class GuiUpdater
    {       
        // Для получения шрифта из ресурсов.
        [DllImport("gdi32.dll")]       
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);
        private static FontFamily _ff;
        private static Font _font;

        private delegate void SetPropertyThreadSafeDelegate<TResult>(Control @this, Expression<Func<TResult>> property, TResult value);

        public static void SetPropertyThreadSafe<TResult>(this Control @this, Expression<Func<TResult>> property, TResult value)
        {
            var propertyInfo = (property.Body as MemberExpression).Member as PropertyInfo;

            if (propertyInfo == null || !@this.GetType().IsSubclassOf(propertyInfo.ReflectedType) || @this.GetType().GetProperty(
                propertyInfo.Name, propertyInfo.PropertyType) == null)
            {
                throw new ArgumentException("The lambda expression 'property' must reference a valid property on this Control.");
            }

            if (@this.InvokeRequired)
            {
                @this.Invoke(new SetPropertyThreadSafeDelegate<TResult>
                (SetPropertyThreadSafe),
                new object[] { @this, property, value });
            }
            else
            {
                @this.GetType().InvokeMember(
                    propertyInfo.Name,
                    BindingFlags.SetProperty,
                    null,
                    @this,
                    new object[] { value });
            }
        }

        public static void CreateNewFlps(FlowLayoutPanel[] channels, FlowLayoutPanel[] allChannels, Panel[] channelsPanels, Panel[] allChannelsPanels)
        {
            if (allChannels[0].Height >= allChannelsPanels[0].Height)
            {
                for (int i = 0; i < 6; i++)
                {
                    allChannels[i].Dispose();
                    allChannels[i] = GetFlp($"flpAllChannels{i}", new Size(242, 8));
                    allChannelsPanels[i].Controls.Add(allChannels[i]);

                    channels[i].Dispose();
                    channels[i] = GetFlp($"flpChannel{i}", new Size(1556, 40));
                    channelsPanels[i].Controls.Add(channels[i]);
                }
            }
        }

        public static void AddImages(FlowLayoutPanel[] channels, FlowLayoutPanel[] allChannels, List<Bitmap>[] listImagesForSave, DirectBitmap[] images)
        {
            for (int i = 0; i < images.Length; i++)
            {
                Bitmap image = new Bitmap(images[i].Bitmap);

                channels[i].Controls.Add(new DoubleBufferedPanel { Size = new Size(Constants.WDT, Constants.HGT), BackgroundImage = image, Margin = new Padding(0) }); 

                allChannels[i].Controls.Add(new DoubleBufferedPanel { Size = new Size(allChannels[i].Width, Constants.HGT), BackgroundImage = image, BackgroundImageLayout = ImageLayout.Stretch, Margin = new Padding(0) }); 

            listImagesForSave[i].Add(image);
            }
        }

        public static void SmoothLoadingForm(Form form)
        {
            form.Opacity = 0;
            Timer timer = new Timer();

            timer.Tick += (sender, e) =>
            {
                if ((form.Opacity += 0.05d) == 1)
                {
                    timer.Stop();
                }
            };

            timer.Interval = 10;
            timer.Start();
        }

        public static void SmoothHidingForm(Form form)
        {
            Timer timer = new Timer();

            timer.Tick += (sender, e) =>
            {
                if ((form.Opacity -= 0.05d) == 0)
                {
                    timer.Stop();
                }
            };

            timer.Interval = 10;
            timer.Start();
        }

        public static FlowLayoutPanel GetFlp(string name, Size size)
        {
            FlowLayoutPanel flp = new FlowLayoutPanel
            {
                Name = name,
                FlowDirection = FlowDirection.TopDown,
                Size = size,
                AutoSize = true,
                Location = new Point(0, 0)
            };

            return flp;
        }

        #region Обновление данных декодирования на GUI.
        public static void UpdateGuiDecodeData(string[] _td, string[] _oshv, string[] _bshv, string[] _pcdm, DateTime _lineDate,
            DisabledRichTextBox rtbDateTime, DisabledRichTextBox rtbMkoData, FlowLayoutPanel[] channels, FlowLayoutPanel[] allChannels, Panel[] channelsPanels, Panel[] allChannelsPanels, List<Bitmap>[] listImagesForSave, DirectBitmap[] images)
        {
            // Собираем данные в richTextBox. Стремновато, но так быстрее. Если использовать 15 лейблов, то время декодирования увеличится где то на 20%.
            var mkoData = $"{_td[0]} {_td[1]}\n\n{_td[2]}\n\n{_td[3]}\n\n{_oshv[0]} {_oshv[1]}\n\n{_bshv[0]} {_bshv[1]}\n\n{_bshv[2]} {_bshv[3]}\n\n{_bshv[4]} {_bshv[5]}\n\n{_bshv[6]} {_bshv[7]}\n\n{_bshv[8]} {_bshv[9]}\n\n{_pcdm[0]} {_pcdm[1]}\n\n{_pcdm[2]} {_pcdm[3]} {_pcdm[4]} {_pcdm[5]}\n\n{_pcdm[6]} {_pcdm[7]} {_pcdm[8]} {_pcdm[9]}\n\n{_pcdm[10]} {_pcdm[11]} {_pcdm[12]} {_pcdm[13]}";
            var date = $"{_lineDate.Day}.{_lineDate.Month}.{_lineDate.Year}";
            var time = $"{_lineDate.Hour.ToString("D2")}:{_lineDate.Minute.ToString("D2")}:{_lineDate.Second.ToString("D2")}";
            var dateTime = $"\n{date}\n\n{time}";

            rtbDateTime.SetPropertyThreadSafe(() => rtbDateTime.Text, dateTime);
            rtbMkoData.SetPropertyThreadSafe(() => rtbMkoData.Text, mkoData);

            // Изображение.
            allChannelsPanels[5].Invoke(new Action(() => { GuiUpdater.CreateNewFlps(channels, allChannels, channelsPanels, allChannelsPanels); }));
            allChannels[5].Invoke(new Action(() => { GuiUpdater.AddImages(channels, allChannels, listImagesForSave, images); }));
        }
        #endregion

        #region Применение шрифта к контролу.
        public static void AllocFont(Font f, Control c, float size)
        {
            FontStyle fontStyle = FontStyle.Regular;
            c.Font = new Font(_ff, size, fontStyle);
        }

        #endregion

        #region Загрузка шрифта из ресурсов.
        public static void LoadFont()
        {
            byte[] fontArray = Resources.Roboto_Regular;
            int dataLength = Resources.Roboto_Regular.Length;

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

        #region Инициализация кастомного richTextBox с данными декодирования.
        public static void DecodeRichTextBoxInit(DisabledRichTextBox rtbMko, DisabledRichTextBox rtbMkoData, DisabledRichTextBox rtbDateTimeTitle, DisabledRichTextBox rtbDateTime)
        {
            AllocFont(_font, rtbMko, 11);
            AllocFont(_font, rtbMkoData, 11);
            AllocFont(_font, rtbDateTimeTitle, 11);
            AllocFont(_font, rtbDateTime, 11);

            var MkoTitle = "Время конца формирования ТД (БШВ)\n\n" +
                "Первый год в текущем четырехлетии\n\n" +
                "Номер текущих суток четырехлетия\n\n" +
                "Оцифрованная бортовая шкала времени (БШВ)\n\n" +
                "Время конца формирования ППО (БШВ)\n\n" +
                "Параметры кватерниона L0\n\n" +
                "Параметры кватерниона L1\n\n" +
                "Параметры кватерниона L2\n\n" +
                "Параметры кватерниона L3\n\n" +
                "Время конца формирования ПЦДМ (БШВ)\n\n" +
                "Положение КА по оси X в формате IEEE-754 двойной\n\n" +
                "Положение КА по оси Y в формате IEEE-754 двойной\n\n" +
                "Положение КА по оси Z в формате IEEE-754 двойной";
            rtbMko.Text = MkoTitle;
            rtbMko.BorderStyle = BorderStyle.None;

            var mkoData = "0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0";
            rtbMkoData.Text = mkoData;
            rtbMkoData.BorderStyle = BorderStyle.None;

            var dateTimeTitle = "\nДата\n\nВремя";
            rtbDateTimeTitle.Text = dateTimeTitle;
            rtbDateTimeTitle.BorderStyle = BorderStyle.None;

            var dateTime = "\n0.0.0\n\n0:0:0";
            rtbDateTime.Text = dateTime;
            rtbDateTime.BorderStyle = BorderStyle.None;
        }

        #endregion
    }
}

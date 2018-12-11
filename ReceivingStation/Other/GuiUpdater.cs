using ReceivingStation.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReceivingStation.Decode;

namespace ReceivingStation.Other
{
    static class GuiUpdater
    {       
        // Для получения шрифта из ресурсов.
        [DllImport("gdi32.dll")]       
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);
        private static FontFamily _ff;
        public static Font Font;

        public static Color ErrorColor = Color.FromArgb(222, 211, 47, 47);
        public static Color OkColor = Color.FromArgb(222, 46, 125, 50);

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

        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        public static void CreateNewFlps(FlowLayoutPanel[] channels, FlowLayoutPanel[] allChannels, Panel[] pChannels, Panel[] pAllChannels)
        {
            if (allChannels[0].Height >= pAllChannels[0].Height)
            {
                for (int i = 0; i < 6; i++)
                {
                    allChannels[i].Dispose();
                    allChannels[i] = GetFlp(new Size(242, 8));
                    pAllChannels[i].Controls.Add(allChannels[i]);

                    channels[i].Dispose();
                    channels[i] = GetFlp(new Size(1556, 40));
                    pChannels[i].Controls.Add(channels[i]);
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

        public static FlowLayoutPanel GetFlp(Size size)
        {
            FlowLayoutPanel flp = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                Size = size,
                AutoSize = true,
                Location = new Point(0, 0)
            };

            return flp;
        }

        #region Обновление данных декодирования на GUI.
        public static void UpdateGuiDecodeData(string linesTd, string linesOshv, string linesBshv, string linesPcdm, DateTime linesDate,
            DisabledRichTextBox rtbDateTime, DisabledRichTextBox rtbMkoData, FlowLayoutPanel[] channels, FlowLayoutPanel[] allChannels, Panel[] channelsPanels, Panel[] allChannelsPanels, List<Bitmap>[] listImagesForSave, DirectBitmap[] imagesLines)
        {
            var td = linesTd.Split(' ');
            var oshv = linesOshv.Split(' ');
            var bshv = linesBshv.Split(' ');
            var pcdm = linesPcdm.Split(' ');

            // Собираем данные в richTextBox. Стремновато, но так быстрее. Если использовать 15 лейблов, то время декодирования увеличится где то на 20%.
            var mkoData = $"{td[0]} {td[1]}\n\n{td[2]}\n\n{td[3]}\n\n{oshv[0]} {oshv[1]}\n\n{bshv[0]} {bshv[1]}\n\n{bshv[2]} {bshv[3]}\n\n{bshv[4]} {bshv[5]}\n\n{bshv[6]} {bshv[7]}\n\n{bshv[8]} {bshv[9]}\n\n{pcdm[0]} {pcdm[1]}\n\n{pcdm[2]} {pcdm[3]} {pcdm[4]} {pcdm[5]}\n\n{pcdm[6]} {pcdm[7]} {pcdm[8]} {pcdm[9]}\n\n{pcdm[10]} {pcdm[11]} {pcdm[12]} {pcdm[13]}";
            var date = $"{linesDate.Day}.{linesDate.Month}.{linesDate.Year}";
            var time = $"{linesDate.Hour:D2}:{linesDate.Minute:D2}:{linesDate.Second:D2}";
            var dateTime = $"\n{date}\n\n{time}";

            try
            {
                rtbDateTime.Text = dateTime;
            }
            catch (Exception e)
            {
                Console.WriteLine("трай на rtbDateTime");
            }

            try
            {
                rtbMkoData.Text = mkoData;
            }
            catch (Exception e)
            {
                Console.WriteLine("трай на rtbMkoData");
            }
            

            // Изображение.
            try
            {
                CreateNewFlps(channels, allChannels, channelsPanels, allChannelsPanels);
            }
            catch (Exception e)
            {
                Console.WriteLine("трай на создание флп");
            }

            try
            {
                AddImages(channels, allChannels, listImagesForSave, imagesLines);
            }
            catch (Exception e)
            {
                Console.WriteLine("трай на эд ченелс");
            }
            

            //rtbDateTime.SetPropertyThreadSafe(() => rtbDateTime.Text, dateTime);
            //rtbMkoData.SetPropertyThreadSafe(() => rtbMkoData.Text, mkoData);

            //pAllChannels[5].Invoke(new Action(() => CreateNewFlps(channels, allChannels, pChannels, pAllChannels)));
            //allChannels[5].Invoke(new Action(() => AddImages(channels, allChannels, listImagesForSave, imagesLines)));
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
            Font = new Font(_ff, 15f, FontStyle.Bold);
        }

        #endregion

        #region Инициализация кастомного richTextBox с данными декодирования.
        public static void DecodeRichTextBoxInit(DisabledRichTextBox rtbMko, DisabledRichTextBox rtbMkoData, DisabledRichTextBox rtbDateTimeTitle, DisabledRichTextBox rtbDateTime)
        {
            AllocFont(Font, rtbMko, 11);
            AllocFont(Font, rtbMkoData, 11);
            AllocFont(Font, rtbDateTimeTitle, 11);
            AllocFont(Font, rtbDateTime, 11);

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

            var dateTimeTitle = "\nМКО Дата:\n\nМКО Время:";
            rtbDateTimeTitle.Text = dateTimeTitle;
            rtbDateTimeTitle.BorderStyle = BorderStyle.None;

            var dateTime = "\n0.0.0\n\n0:0:0";
            rtbDateTime.Text = dateTime;
            rtbDateTime.BorderStyle = BorderStyle.None;
        }

        #endregion
    }
}

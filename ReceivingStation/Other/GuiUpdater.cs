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
        public static Font font;
        // Для получения шрифта из ресурсов.
        [DllImport("gdi32.dll")]       
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);
        private static FontFamily _ff;        
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

        public static void AllocFont(Font f, Control c, float size)
        {
            FontStyle fontStyle = FontStyle.Regular;
            c.Font = new Font(_ff, size, fontStyle);

        }

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
            font = new Font(_ff, 15f, FontStyle.Bold);
        }
    }
}

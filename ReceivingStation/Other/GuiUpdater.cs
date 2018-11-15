using ReceivingStation.Decode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ReceivingStation.Other
{
    static class GuiUpdater
    {
        public static void SetLabelText(Label label , string text)
        {
            label.Text = text;
        }

        public static void AddImages(FlowLayoutPanel[] channels, FlowLayoutPanel[] allChannels, List<Bitmap>[] listImagesForSave, DirectBitmap[] images)
        {
            for (int i = 0; i < images.Length; i++)
            {
                Bitmap image = new Bitmap(images[i].Bitmap);

                channels[i].Controls.Add(new DoubleBufferedPanel { Size = new Size(Constants.WDT, Constants.HGT), BackgroundImage = image, Margin = new Padding(0) });

                allChannels[i].Controls.Add(new DoubleBufferedPanel { Size = new Size(Constants.WDT, Constants.HGT), BackgroundImage = image, Margin = new Padding(0) });

                listImagesForSave[i].Add(image);
            }
        }

        public static void SmoothLoadingForm(Form form)
        {
            form.Opacity = 0;
            Timer timer = new Timer();

            timer.Tick += new EventHandler((sender, e) =>
            {
                if ((form.Opacity += 0.05d) == 1)
                {
                    timer.Stop();
                }
            });

            timer.Interval = 10;
            timer.Start();
        }

        public static void SmoothHidingForm(Form form)
        {
            Timer timer = new Timer();

            timer.Tick += new EventHandler((sender, e) =>
            {
                if ((form.Opacity -= 0.05d) == 0)
                {
                    timer.Stop();
                }
            });

            timer.Interval = 10;
            timer.Start();
        }
    }
}

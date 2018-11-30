using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;

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

                allChannels[i].Controls.Add(new DoubleBufferedPanel { Size = new Size(allChannels[i].Width, Constants.HGT), BackgroundImage = image, BackgroundImageLayout = ImageLayout.Stretch, Margin = new Padding(0) });

                listImagesForSave[i].Add(image);
            }
        }

        public static void UpdateMko(MaterialLabel[] labels, string td, string oshv, string bshv, string pcdm)
        {
            string[] tdd = td.Split(' ');
            string[] oshvv = oshv.Split(' ');
            string[] bshvv = bshv.Split(' ');
            string[] pcdmm = pcdm.Split(' ');

            // ТД.
            labels[0].Text = $"{tdd[0]} {tdd[1]}";
            labels[1].Text = $"{tdd[2]}";
            labels[2].Text = $"{tdd[3]}";

            // ОШВ.
            labels[3].Text = $"{oshvv[0]} {oshvv[1]}";

            // БШВ.
            labels[4].Text = $"{bshvv[0]} {bshvv[1]}";
            labels[5].Text = $"{bshvv[2]} {bshvv[3]}";
            labels[6].Text = $"{bshvv[4]} {bshvv[5]}";
            labels[7].Text = $"{bshvv[6]} {bshvv[7]}";
            labels[8].Text = $"{bshvv[8]} {bshvv[9]}";

            // ПЦДМ.
            labels[9].Text = $"{pcdmm[0]} {pcdmm[1]}";
            labels[10].Text = $"{pcdmm[2]} {pcdmm[3]} {pcdmm[4]} {pcdmm[5]}";
            labels[11].Text = $"{pcdmm[6]} {pcdmm[7]} {pcdmm[8]} {pcdmm[9]}";
            labels[12].Text = $"{pcdmm[10]} {pcdmm[11]} {pcdmm[12]} {pcdmm[13]}";
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

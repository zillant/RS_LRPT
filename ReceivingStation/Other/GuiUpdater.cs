using ReceivingStation.Decode;
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
    }
}

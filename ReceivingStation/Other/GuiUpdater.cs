using ReceivingStation.Decode;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ReceivingStation.Other
{
    class GuiUpdater
    {
        public void UpdateFrameCounterValue(Label label , uint counter)
        {
            label.Text = counter.ToString();
        }

        public void AddImages(FlowLayoutPanel[] channels, FlowLayoutPanel[] allChannels, List<Bitmap>[] listImagesForSave, DirectBitmap[] images)
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

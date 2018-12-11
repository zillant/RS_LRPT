using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using ReceivingStation.Decode;

namespace ReceivingStation.Other
{
    static class ImageSaver
    {
        #region Сохранение изображений.
        public static void SaveImage(List<Bitmap>[] listImagesForSave, string fileName, long imageCounter)
        {
            Parallel.For(0, listImagesForSave.Length, i =>
            {
                List<Bitmap> listImages = new List<Bitmap>(listImagesForSave[i]);
                listImagesForSave[i].Clear();

                using (var bmp = new Bitmap(Constants.WDT, listImages.Count * Constants.HGT))
                {
                    using (var g = Graphics.FromImage(bmp))
                    {
                        int yOffset = 0;

                        for (int j = 0; j < listImages.Count; j++)
                        {
                            g.DrawImage(listImages[j], new Rectangle(0, yOffset, Constants.WDT, Constants.HGT));
                            yOffset += Constants.HGT;
                        }
                    }

                    bmp.Save($"{Path.GetDirectoryName(fileName)}\\{Path.GetFileNameWithoutExtension(fileName)}_Channel_{i + 1}\\{Path.GetFileNameWithoutExtension(fileName)}_{i + 1}_{imageCounter}.bmp");
                }
            });          
        }

        #endregion

        #region Создание полного изображения (Работает на маленьких изображениях, создать картинку 15ХХ х Over9000 конечно не получится).
        public static void CreateFullImage(string fileName)
        {
            Parallel.For(0, 6, i =>
            {
                DirectoryInfo di = new DirectoryInfo($"{Path.GetDirectoryName(fileName)}\\{Path.GetFileNameWithoutExtension(fileName)}_Channel_{i + 1}");
                List<Bitmap> images = new List<Bitmap>();

                foreach (FileInfo file in di.GetFiles())
                {
                    images.Add(new Bitmap(file.FullName));
                }

                using (var bmp = new Bitmap(Constants.WDT, images.Count * 960))
                {
                    using (var g = Graphics.FromImage(bmp))
                    {
                        int yOffset = 0;

                        for (int j = 0; j < images.Count; j++)
                        {
                            g.DrawImage(images[j], new Rectangle(0, yOffset, Constants.WDT, images[j].Height));
                            yOffset += images[j].Height;
                        }
                    }

                    bmp.Save($"{Path.GetDirectoryName(fileName)}\\{Path.GetFileNameWithoutExtension(fileName)}_{i + 1}.bmp");
                }
            });
        }

        #endregion
    }
}

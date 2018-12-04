using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace ReceivingStation.Other
{
    internal static class ImageSaver
    {
        #region Сохранение изображений.
        public static void SaveImage(List<Bitmap>[] _listImagesForSave, string _fileName, long _imageCounter)
        {
            Parallel.For(0, _listImagesForSave.Length, i =>
            {
                List<Bitmap> listImages = new List<Bitmap>(_listImagesForSave[i]);
                _listImagesForSave[i].Clear();

                using (Bitmap bmp = new Bitmap(Constants.WDT, listImages.Count * Constants.HGT))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        int yOffset = 0;

                        for (int j = 0; j < listImages.Count; j++)
                        {
                            g.DrawImage(listImages[j], new Rectangle(0, yOffset, Constants.WDT, Constants.HGT));
                            yOffset += Constants.HGT;
                        }
                    }

                    bmp.Save($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_Channel_{i + 1}\\{Path.GetFileNameWithoutExtension(_fileName)}_{i + 1}_{_imageCounter}.bmp");
                }
            });          
        }

        #endregion

        #region Создание полного изображения (Работает на маленьких изображениях, создать картинку 15ХХ х Over9000 конечно не получится).
        public static void CreateFullImage(string _fileName)
        {
            Parallel.For(0, 6, i =>
            {
                DirectoryInfo di = new DirectoryInfo($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_Channel_{i + 1}");
                List<Bitmap> images = new List<Bitmap>();

                foreach (FileInfo file in di.GetFiles())
                {
                    images.Add(new Bitmap(file.FullName));
                }

                using (Bitmap bmp = new Bitmap(Constants.WDT, images.Count * 960))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        int yOffset = 0;

                        for (int j = 0; j < images.Count; j++)
                        {
                            g.DrawImage(images[j], new Rectangle(0, yOffset, Constants.WDT, images[j].Height));
                            yOffset += images[j].Height;
                        }
                    }

                    bmp.Save($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_{i + 1}.bmp");
                }
            });
        }

        #endregion
    }
}

using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DeszkaImageViewer.Core.Utils;

public static class ImageUtils
{
    public static class Save
    {
        public static void ToPng(string savePath, ImageSource image)
        {
            using var fileStream = new FileStream(savePath, FileMode.Create);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
            encoder.Save(fileStream);
        }

        public static void ToJpeg(string savePath, ImageSource image)
        {
            using var fileStream = new FileStream(savePath, FileMode.Create);

            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
            encoder.Save(fileStream);
        }

        public static void ToBmp(string savePath, ImageSource image)
        {
            using var fileStream = new FileStream(savePath, FileMode.Create);

            var encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
            encoder.Save(fileStream);
        }

        public static void ToGif(string savePath, ImageSource image)
        {
            using var fileStream = new FileStream(savePath, FileMode.Create);

            var encoder = new GifBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
            encoder.Save(fileStream);
        }
    }
}

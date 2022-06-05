using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DeszkaImageViewer.Core.Utils;

public class ImageUtils
{
    public readonly SaveHandler Save;

    public ImageUtils()
    {
        Save = new SaveHandler();
    }

    public class SaveHandler
    {
        public void ToPng(string savePath, ImageSource image)
        {
            using var fileStream = new FileStream(savePath, FileMode.Create);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
            encoder.Save(fileStream);
        }

        public void ToJpeg(string savePath, ImageSource image)
        {
            using var fileStream = new FileStream(savePath, FileMode.Create);

            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
            encoder.Save(fileStream);
        }

        public void ToBmp(string savePath, ImageSource image)
        {
            using var fileStream = new FileStream(savePath, FileMode.Create);

            var encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
            encoder.Save(fileStream);
        }

        public void ToGif(string savePath, ImageSource image)
        {
            using var fileStream = new FileStream(savePath, FileMode.Create);

            var encoder = new GifBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
            encoder.Save(fileStream);
        }
    }
}

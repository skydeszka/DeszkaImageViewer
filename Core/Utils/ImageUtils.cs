using System.Drawing;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DeszkaImageViewer.Core.Utils;

public class ImageUtils
{
    public readonly SaveHandler Save;
    public readonly string Filter =
        "All Files|*.*|" +
        "PNG (*.png)|*.png|" +
        "JPG (*.jpg)|*.jpg|" +
        "JPEG (*.jpeg)|*.jpeg|" +
        "Bitmap (*.bmp)|*.bmp|" +
        "GIF (*.gif)|*.gif";

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

    public Bitmap Resize(BitmapImage image, int width, int height)
    {
        var a = image as Image;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DeszkaImageViewer.Core.Utils;

public class MainWindowUtils
{
    public void Export(string extension, ImageSource src)
    {
        
        var path = "";
        var filter = $"{extension.ToUpper()}|*.{extension}";

        if (!SaveDialogUtils.OpenSaveDialog(filter, out path))
            return;

        switch(extension)
        {
            case "png":
                ImageUtils.Save.ToPng(path, src);
                break;
            case "jpeg":
                ImageUtils.Save.ToJpeg(path, src);
                break;
            case "gif":
                ImageUtils.Save.ToGif(path, src);
                break;
            case "bmp":
                ImageUtils.Save.ToBmp(path, src);
                break;
            default:
                return;
        }
    }
}
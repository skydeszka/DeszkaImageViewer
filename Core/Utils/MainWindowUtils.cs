using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DeszkaImageViewer.Core.Utils;

public class MainWindowUtils
{
    private readonly DialogUtils _dialogUtils;
    private readonly ImageUtils _imageUtils;

    public MainWindowUtils(DialogUtils dialogUtils, ImageUtils imageUtils)
    {
        _dialogUtils = dialogUtils;
        _imageUtils = imageUtils;
    }

    public void Export(string extension, ImageSource src)
    {
        
        var path = "";
        var filter = $"{extension.ToUpper()}|*.{extension}";

        if (_dialogUtils.OpenSaveDialog(filter, out path))
            return;

        switch(extension)
        {
            case "png":
                _imageUtils.Save.ToPng(path, src);
                break;
            case "jpeg":
                _imageUtils.Save.ToJpeg(path, src);
                break;
            case "gif":
                _imageUtils.Save.ToGif(path, src);
                break;
            case "bmp":
                _imageUtils.Save.ToBmp(path, src);
                break;
            default:
                return;
        }
    }
}
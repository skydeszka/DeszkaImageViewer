using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DeszkaImageViewer.Core.Utils;

public class MainWindowUtils
{
    private readonly DialogUtils _dialogUtils;
    private readonly ImageUtils _imageUtils;
    private readonly BrushConverter _converter;

    private string[]? _otherFiles;
    private FileInfo? _info;
    private uint _index = 0;
    private BitmapImage? _rawImage;

    public string[]? OtherFiles
    {
        get
        {
            return _otherFiles;
        }
    }

    public FileInfo? Info
    {
        get
        {
            return _info;
        }
    }

    public uint Index
    {
        get
        {
            return _index;
        }
        set
        {
            _index = value;
            _index = Math.Max(_index, 0);
            if (_index > _otherFiles?.Length)
                _index = (uint)_otherFiles.Length - 1;
        }
    }

    public BitmapImage? RawImage
    {
        get
        {
            return _rawImage;
        }
    }

    public MainWindowUtils(DialogUtils dialogUtils, ImageUtils imageUtils)
    {
        _dialogUtils = dialogUtils;
        _imageUtils = imageUtils;
        _converter = new BrushConverter();
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
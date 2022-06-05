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

    public void ChangeImage()
    {
        if (_otherFiles is null)
            return;

        _info = new FileInfo(_otherFiles[_index]);

        _rawImage = new BitmapImage();
        _rawImage.BeginInit();
        _rawImage.UriSource = new Uri(_info.Directory + "\\" + _info.Name);
        _rawImage.EndInit();
    }
    
    internal void Initialize()
    {
        if (!App.HasArgs)
            return;

        _info = new FileInfo(App.Args[0]);

        if (_info is null)
            return;

        _rawImage = new BitmapImage();
        _rawImage.BeginInit();
        _rawImage.UriSource = new Uri(_info.Directory + "\\" + _info.Name);
        _rawImage.EndInit();

        ImageCanvas.Source = _rawImage;

        if (_info.DirectoryName is null)
            return;

        _otherFiles = Directory.GetFiles(_info.DirectoryName, $"*{_info.Extension}");
        for (int i = 0; i < _otherFiles.Length; i++)
        {
            if (_otherFiles[i] != _info.FullName)
                continue;

            _index = (uint)i;
        }
    }
}
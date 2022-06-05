using DeszkaImageViewer.Core.Utils;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DeszkaImageViewer;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string[]? _otherFiles;
    private FileInfo? _info;
    private uint _index = 0;
    private BitmapImage? _rawImage;
    private BrushConverter _converter;

    private MainWindowUtils _utils;

    public MainWindow(MainWindowUtils utils)
    {
        InitializeComponent();
        _converter = new BrushConverter();
        _utils = utils;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
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

    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void NextImageButton_Click(object sender, RoutedEventArgs e)
    {
        if (_otherFiles is null)
            return;
        
        ++_index;
        if (_index >= _otherFiles.Length)
            _index = 0;

        _info = new FileInfo(_otherFiles[_index]);

        _rawImage = new BitmapImage();
        _rawImage.BeginInit();
        _rawImage.UriSource = new Uri(_info.Directory + "\\" + _info.Name);
        _rawImage.EndInit();

        ImageCanvas.Source = _rawImage;
    }

    private void PreviousImageButton_Click(object sender, RoutedEventArgs e)
    {
        if (_otherFiles is null)
            return;

        _index = _index == 0 ?
            (uint)_otherFiles.Length - 1 : _index - 1;

        _info = new FileInfo(_otherFiles[_index]);

        _rawImage = new BitmapImage();
        _rawImage.BeginInit();
        _rawImage.UriSource = new Uri(_info.Directory + "\\" + _info.Name);
        _rawImage.EndInit();

        ImageCanvas.Source = _rawImage;
    }

    private void ExportMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var tag = ((MenuItem)sender).Tag.ToString();

        if (tag is null)
            return;

        _utils.Export(tag, ImageCanvas.Source);
    }
}


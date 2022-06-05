﻿using DeszkaImageViewer.Core.Utils;
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
    

    private readonly MainWindowUtils _utils;

    public MainWindow(MainWindowUtils utils)
    {
        InitializeComponent();
        _utils = utils;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        _utils.Initialize();
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
        _utils.Index++;
        _utils.ChangeImage();
        ImageCanvas.Source = _utils.RawImage;
    }

    private void PreviousImageButton_Click(object sender, RoutedEventArgs e)
    {
        _utils.Index--;
        _utils.ChangeImage();
        ImageCanvas.Source = _utils.RawImage;
    }

    private void ExportMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var tag = ((MenuItem)sender).Tag.ToString();

        if (tag is null)
            return;

        _utils.Export(tag, ImageCanvas.Source);
    }

    private void OpenImageButton_Click(object sender, RoutedEventArgs e)
    {

    }
}


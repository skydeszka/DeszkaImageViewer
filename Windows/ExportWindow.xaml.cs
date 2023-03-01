using DeszkaImageViewer.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DeszkaImageViewer.Windows;
/// <summary>
/// Interaction logic for ExportWindow.xaml
/// </summary>
public partial class ExportWindow : Window
{
    private readonly ExportWindowUtils _utils;
    private readonly BitmapImage _imageSource;

    public ExportWindow(ExportWindowUtils utils, BitmapImage imageSource)
    {
        InitializeComponent();
        _utils = utils;
        _imageSource = imageSource;

        ImageCanvas.Source = imageSource;
        WidthTextBox.Text = imageSource.PixelWidth.ToString();
        HeightTextBox.Text = imageSource.PixelHeight.ToString();
    }

    private void MinimizeButton_Click(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

    private void CloseButton_Click(object sender, RoutedEventArgs e) => this.Close();

    private void TestDimensionsInput(object sender, TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;

        if (textBox is null)
            return;

        textBox.IsEnabled = false;

        for(int i = 0; i < textBox.Text.Length; i++)
        {
            if (char.IsDigit(textBox.Text[i]))
                continue;

            textBox.Text = textBox.Text.Remove(i, 1);
        }

        bool widthTextBoxConvertable = WidthTextBox.Text.Length > 0;
        bool heightTextBoxConvertable = HeightTextBox.Text.Length > 0;
        if (widthTextBoxConvertable && heightTextBoxConvertable)
        {
            _imageSource.DecodePixelWidth = int.Parse(WidthTextBox.Text);
            _imageSource.DecodePixelHeight = int.Parse(HeightTextBox.Text);
        }

        textBox.CaretIndex = textBox.Text.Length;

        textBox.IsEnabled = true;

        e.Handled = true;
    }

    private void FileFormatComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}

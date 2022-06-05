using Microsoft.Win32;

namespace DeszkaImageViewer.Core.Utils;

public class DialogUtils
{
    public bool OpenSaveDialog(string filter, out string filePath)
    {
        var saveFileDialg = new SaveFileDialog();

        saveFileDialg.Filter = filter;

        bool? result = saveFileDialg.ShowDialog();

        if (result is null || !result.Value)
        {
            filePath = "";
            return false;
        }

        filePath = saveFileDialg.FileName;
        return true;
    }

}

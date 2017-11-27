using Microsoft.Win32;

namespace ArtificialIntelligenceVisualizer.UI
{
    public class FileDialogFilePathSelector : IFilePathSelector
    {
        public string GetFilePath()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "DLL Files|*.dll"
            };

            bool? success = fileDialog.ShowDialog();

            if (success == true)
            {
                return fileDialog.FileName;
            }

            return null;
        }
    }
}

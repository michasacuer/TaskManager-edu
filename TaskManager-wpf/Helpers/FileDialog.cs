namespace TaskManager.WPF.Helpers
{
    using System;
    using Microsoft.Win32;

    public class FileDialog
    {
        public string OpenSaveFile()
        {
            var saveFileDialog = new SaveFileDialog()
            {
                Filter = "Pdf Files|*.pdf"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                return saveFileDialog.FileName;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}

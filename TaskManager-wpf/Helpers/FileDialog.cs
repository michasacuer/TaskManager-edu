namespace TaskManager.WPF.Helpers
{
    using Microsoft.Win32;
    using System.Drawing.Printing;
    using System.Windows.Forms;

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

        public void OpenPrinterDialog(PrintDocument printDocument)
        {
            var printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
    }
}

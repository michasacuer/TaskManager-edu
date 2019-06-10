namespace TaskManager.WPF.Helpers
{
    using System.Linq;
    using System.Threading.Tasks;
    using IronPdf;
    using TaskManager.Models;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class ManagerPanelHelper
    {
        public async void GeneratePdf(string projectName, string filepath)
        {
            var pdf = await this.GetPdf(projectName);

            var htmlToPdf = new HtmlToPdf();
            htmlToPdf.RenderHtmlAsPdf(pdf.Content).SaveAs(filepath);

            Show.Pdf(filepath);
        }

        public async void PrintRaport(string projectName)
        {
            var pdf = await this.GetPdf(projectName);

            var htmlToPdf = new HtmlToPdf();
            var render = htmlToPdf.RenderHtmlAsPdf(pdf.Content);

            var printDocument = render.GetPrintDocument();

            var fileDialog = new FileDialog();
            fileDialog.OpenPrinterDialog(printDocument);
        }

        private async Task<Pdf> GetPdf(string projectName)
        {
            var projectId = Repository.Instance.Projects.Single(p => p.Name == projectName).Id;

            var httpDataService = new HttpDataService();
            return await httpDataService.Get<Pdf>(projectId);
        }
    }
}

namespace TaskManager.WPF.Helpers
{
    using System.Linq;
    using IronPdf;
    using TaskManager.Models;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class ManagerPanelHelper
    {
        public async void GeneratePdf(string projectName, string filepath)
        {
            var projectId = Repository.Instance.Projects.Single(p => p.Name == projectName).Id;

            var httpDataService = new HttpDataService();
            var pdf = await httpDataService.Get<Pdf>(projectId);

            var htmlToPdf = new HtmlToPdf();
            htmlToPdf.RenderHtmlAsPdf(pdf.Content).SaveAs(filepath);

            Show.Pdf(filepath);
        }
    }
}

namespace TaskManager_WebApi.Controllers
{
    using System.Text;
    using Microsoft.AspNetCore.Mvc;
    using TaskManager.WebApi.Services;

    [Route("[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IPdfService pdfService;

        public PdfController(IPdfService pdfService)
        {
            this.pdfService = pdfService;
        }

        [HttpGet("{projectId}")]
        public string GetRaportFromProject([FromRoute] int projectId)
        {
            return this.pdfService.RenderViewToHtml(projectId);
        }
    }
}
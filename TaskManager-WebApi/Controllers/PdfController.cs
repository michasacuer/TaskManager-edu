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
        public IActionResult GetRaportFromProject([FromRoute] int projectId)
        {
            var html = this.pdfService.RenderViewToHtml(projectId);
            return this.Content(html, "text/html", Encoding.UTF8);
        }
    }
}
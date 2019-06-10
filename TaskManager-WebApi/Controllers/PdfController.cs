namespace TaskManager_WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TaskManager.Models;
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
            return this.Ok(new Pdf
            {
                Content = html
            });
        }
    }
}
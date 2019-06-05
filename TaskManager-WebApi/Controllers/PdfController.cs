namespace TaskManager_WebApi.Controllers
{
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
    }
}
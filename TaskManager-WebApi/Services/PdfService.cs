namespace TaskManager.WebApi.Services
{
    using System;

    public class PdfService : IPdfService
    {
        private readonly IProjectService projectService;

        public PdfService(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        public string GeneratePdf(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}

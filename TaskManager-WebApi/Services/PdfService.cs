namespace TaskManager.WebApi.Services
{
    using System;
    using System.IO;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Abstractions;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Routing;
    using TaskManager.Models.ViewModels;

    public class PdfService : IPdfService
    {
        private readonly IRazorViewEngine razorViewEngine;

        private readonly ITempDataProvider tempDataProvider;

        private readonly IServiceProvider serviceProvider;

        private readonly IProjectService projectService;

        public PdfService(
            IProjectService projectService,
            IRazorViewEngine razorViewEngine,
            ITempDataProvider tempDataProvider,
            IServiceProvider serviceProvider)
        {
            this.projectService = projectService;
            this.razorViewEngine = razorViewEngine;
            this.tempDataProvider = tempDataProvider;
            this.serviceProvider = serviceProvider;
        }

        public string RenderViewToHtml(int projectId)
        {
            var project = this.projectService.GetItem(projectId);

            var httpContext = new DefaultHttpContext { RequestServices = this.serviceProvider };
            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

            using (var sw = new StringWriter())
            {
                string viewPath = "~/PdfTemplate/ProjectRaport.cshtml";
                var viewResult = this.razorViewEngine.GetView(viewPath, viewPath, false);

                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = new ProjectRaportViewModel
                    {
                        Project = project
                    }
                };

                var viewContext = new ViewContext(
                    actionContext,
                    viewResult.View,
                    viewDictionary,
                    new TempDataDictionary(actionContext.HttpContext, this.tempDataProvider),
                    sw,
                    new HtmlHelperOptions());

                viewResult.View.RenderAsync(viewContext);
                return sw.ToString();
            }
        }
    }
}

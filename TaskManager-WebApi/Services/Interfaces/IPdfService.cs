namespace TaskManager.WebApi.Services
{
    public interface IPdfService
    {
        string RenderViewToHtml(int projectId);
    }
}

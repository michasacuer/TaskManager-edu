namespace TaskManager.WebApi.Services
{
    public interface IPdfService
    {
        string GeneratePdf(int projectId);
    }
}

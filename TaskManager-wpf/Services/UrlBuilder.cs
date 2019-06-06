namespace TaskManager.WPF.Services
{
    using System.Linq;

    public static class UrlBuilder
    {
        public static string BaseUrl = "https://localhost:44365";

        //public static string BaseUrl = "https://taskmanager-edu.azurewebsites.net";

        public static string BuildEndponit(string controller) => $"{BaseUrl}/{controller}";

        public static string BuildEndpoint(string controller, int id) => $"{BaseUrl}/{controller}/{id}";

        public static string BuildEndpoint(string controller, string method) => $"{BaseUrl}/{controller}/{method}";

        public static string BuildEndpoint(string controller, string method, int id) => $"{BaseUrl}/{controller}/{method}/{id}";

        public static string BuildEndpoint(string controller, params string[] parameters)
            => BaseUrl + @"/" + controller + parameters.Aggregate(string.Empty, (current, next) => current + @"/" + next);
    }
}

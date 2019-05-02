namespace TaskManager.WPF.Services
{
    using System.Linq;

    public static class UrlService
    {
        private static string url = "https://localhost:44365";

        public static string BuildEndpoit(string controller) => $"{url}/{controller}";

        public static string BuildEndpoint(string controller, int id) => $"{url}/{controller}/{id}";

        public static string BuildEndpoint(string controller, string method) => $"{url}/{controller}/{method}";

        public static string BuildEndpoint(string controller, string method, int id) => $"{url}/{controller}/{method}/{id}";

        public static string BuildEndpoint(params string[] parameters)
            => url + parameters.Aggregate(string.Empty, (current, next) => current + @"/" + next);
    }
}

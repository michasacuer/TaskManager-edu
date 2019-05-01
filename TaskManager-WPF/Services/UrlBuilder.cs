namespace TaskManager.WPF.Services
{
    using System.Linq;

    public static class UrlBuilder
    {
        private static string url = "https://localhost:44365/";

        public static string Build(string controller) => $"{url}/{controller}";

        public static string Build(string controller, string method) => $"{url}/{controller}/{method}";

        public static string Build(string controller, string method, int id) => $"{url}/{controller}/{method}/{id}";

        public static string Build(params string[] parameters)
            => url + parameters.Aggregate(string.Empty, (current, next) => current + @"/" + next);
    }
}

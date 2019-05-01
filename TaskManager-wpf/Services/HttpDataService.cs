namespace TaskManager.WPF.Services
{
    using System;

    public static class HttpDataService
    {
        private static readonly string Url = "https://localhost:44365/";

        public static object Get(string controller, string method)
        {
            throw new NotImplementedException();
        }

        public static object Post(string controller, string method, object data)
        {
            throw new NotImplementedException();
        }

        public static object Put(string controller, string method, object data)
        {
            throw new NotImplementedException();
        }

        private static string UrlBuilder(string controller) => $"{Url}/{controller}";

        private static string UrlBuilder(string controller, string method) => $"{Url}/{controller}/{method}";

        private static string UrlBuilder(string controller, string method, int id) => $"{Url}/{controller}/{method}/{id}";
    }
}

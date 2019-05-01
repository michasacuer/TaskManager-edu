namespace TaskManager.WPF.Services
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class HttpDataService
    {
        public HttpDataService(string token)
        {
            this.HttpClient = new HttpClient();
            this.HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        private HttpClient HttpClient { get; set; }

        public async Task<object> Get(string controller, string method)
        {
            object data;
            HttpResponseMessage response = await this.HttpClient.GetAsync(UrlBuilder.Build(controller, method));

            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsAsync<object>();
                return data;
            }
            else
            {
                throw new Exception();
            }
        }

        public object Post(string controller, string method, object data)
        {
            throw new NotImplementedException();
        }

        public object Put(string controller, string method, object data)
        {
            throw new NotImplementedException();
        }
    }
}

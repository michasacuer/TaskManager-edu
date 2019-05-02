namespace TaskManager.WPF.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class HttpDataService
    {
        public HttpDataService(string token)
        {
            this.HttpClient = new HttpClient();
            this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        private HttpClient HttpClient { get; set; }

        public async Task<IEnumerable<TObject>> Get<TObject>(string controller)
        {
            IEnumerable<TObject> data;
            HttpResponseMessage response = await this.HttpClient.GetAsync(UrlService.BuildEndpoint(controller));

            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsAsync<IEnumerable<TObject>>();
                return data;
            }
            else
            {
                throw new Exception(); //todo
            }
        }

        public async Task<TObject> Get<TObject>(string controller, int id)
        {
            TObject data;
            HttpResponseMessage response = await this.HttpClient.GetAsync(UrlService.BuildEndpoint(controller, id));

            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsAsync<TObject>();
                return data;
            }
            else
            {
                throw new Exception(); //todo
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

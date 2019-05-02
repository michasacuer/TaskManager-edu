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

        public async Task<IEnumerable<TObject>> Get<TObject>()
        {
            string controller = typeof(TObject).Name;

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

        public async Task<TObject> Get<TObject>(int id)
        {
            string controller = typeof(TObject).Name;

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

        public async Task Post<TObject>(TObject data)
        {
            string controller = typeof(TObject).Name;

            HttpResponseMessage response = await this.HttpClient.PostAsJsonAsync(UrlService.BuildEndpoint(controller), data);
        }

        public async Task Put<TObject>(TObject data, int id)
        {
            string controller = typeof(TObject).Name;

            HttpResponseMessage response = await this.HttpClient.PutAsJsonAsync(UrlService.BuildEndpoint(controller, id), data);
        }

        public async Task Delete<TObject>(TObject data, int id)
        {
            string controller = typeof(TObject).Name;

            HttpResponseMessage response = await this.HttpClient.DeleteAsync(UrlService.BuildEndpoint(controller, id));
        }
    }
}

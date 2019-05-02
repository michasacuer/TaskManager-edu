namespace TaskManager.WPF.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Models.BindingModels;

    public class HttpDataService
    {
        public HttpDataService()
        {
            this.HttpClient = new HttpClient();
        }

        private HttpClient HttpClient { get; set; }

        public async Task<Account> Login(LoginBindingModel login)
        {
            HttpResponseMessage response
                = await this.HttpClient.PostAsJsonAsync(UrlService.BuildEndpoint("Account", "Login"), login);

            response.EnsureSuccessStatusCode();

            Account account = JsonConvert.DeserializeObject<Account>(await response.Content.ReadAsStringAsync());

            this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", account.Bearer);

            return account;
        }

        public async Task<string> Register(RegistrationBindingModel account)
        {
            HttpResponseMessage response
                = await this.HttpClient.PostAsJsonAsync(UrlService.BuildEndpoint("Account", "Register"), account);

            string statusCode = response.StatusCode.ToString();

            if (statusCode.Equals("Conflict"))
            {
                throw new ArgumentException("Błąd serwera, sprawdź formularz!");
            }
            else
            {
                return statusCode;
            }
        }

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

        public async Task<TObject> Post<TObject>(TObject data)
        {
            string controller = typeof(TObject).Name;

            HttpResponseMessage response = await this.HttpClient.PostAsJsonAsync(UrlService.BuildEndpoint(controller), data);

            return data;
        }

        public async System.Threading.Tasks.Task Put<TObject>(TObject data, int id)
        {
            string controller = typeof(TObject).Name;

            HttpResponseMessage response = await this.HttpClient.PutAsJsonAsync(UrlService.BuildEndpoint(controller, id), data);
        }

        public async System.Threading.Tasks.Task Delete<TObject>(TObject data, int id)
        {
            string controller = typeof(TObject).Name;

            HttpResponseMessage response = await this.HttpClient.DeleteAsync(UrlService.BuildEndpoint(controller, id));
        }
    }
}

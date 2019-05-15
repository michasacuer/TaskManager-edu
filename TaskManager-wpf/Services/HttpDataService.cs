namespace TaskManager.WPF.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using TaskManager.WPF.Exceptions;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Models.BindingModels;
    using TaskManager.WPF.Strings;

    public class HttpDataService
    {
        public HttpDataService()
        {
            this.HttpClient = new HttpClient();
        }

        private HttpClient HttpClient { get; set; }

        public async System.Threading.Tasks.Task TestServerConnection()
        {
            HttpResponseMessage response
                = await this.HttpClient.GetAsync(UrlBuilder.BuildEndpoint("Test"));
        }

        public async Task<Account> Login(LoginBindingModel login)
        {
            HttpResponseMessage response
                = await this.HttpClient.PostAsJsonAsync(UrlBuilder.BuildEndpoint("Account", "Login"), login);

            string statusCode = response.StatusCode.ToString();

            Account account = JsonConvert.DeserializeObject<Account>(await response.Content.ReadAsStringAsync());

            if (statusCode.Equals("Unauthorized"))
            {
                throw new ExternalLoginException(Error.ExternalLogin);
            }
            else
            {
                this.HttpClient.DefaultRequestHeaders.Authorization
                    = new AuthenticationHeaderValue("Bearer", account.Bearer);
                return account;
            }
        }

        public async Task<string> Register(RegistrationBindingModel account)
        {
            HttpResponseMessage response
                = await this.HttpClient.PostAsJsonAsync(UrlBuilder.BuildEndpoint("Account", "Register"), account);

            string statusCode = response.StatusCode.ToString();

            if (statusCode.Equals("Conflict"))
            {
                throw new RegistrationException(Error.Registration);
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
            HttpResponseMessage response
                = await this.HttpClient.GetAsync(UrlBuilder.BuildEndpoint(controller));

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
            HttpResponseMessage response
                = await this.HttpClient.GetAsync(UrlBuilder.BuildEndpoint(controller, id));

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

            HttpResponseMessage response = await this.HttpClient.PostAsJsonAsync(UrlBuilder.BuildEndpoint(controller), data);

            return data;
        }

        public async System.Threading.Tasks.Task Put<TObject>(TObject data, int id)
        {
            string controller = typeof(TObject).Name;

            HttpResponseMessage response = await this.HttpClient.PutAsJsonAsync(UrlBuilder.BuildEndpoint(controller, id), data);
        }

        public async System.Threading.Tasks.Task Delete<TObject>(TObject data, int id)
        {
            string controller = typeof(TObject).Name;

            HttpResponseMessage response = await this.HttpClient.DeleteAsync(UrlBuilder.BuildEndpoint(controller, id));
        }
    }
}
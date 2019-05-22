namespace TaskManager.WPF.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Formatting;
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

        public async Task<User> Login(LoginBindingModel login)
        {
            HttpResponseMessage response
                = await this.HttpClient.PostAsJsonAsync(UrlBuilder.BuildEndpoint("Account", "Login"), login);

            string statusCode = response.StatusCode.ToString();

            User account = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());

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

            HttpResponseMessage response
                = await this.HttpClient.GetAsync(UrlBuilder.BuildEndpoint(controller));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<TObject>>();
            }
            else
            {
                throw new Exception(); //todo
            }
        }

        public async Task<TObject> Get<TObject>(int id)
        {
            string controller = typeof(TObject).Name;

            HttpResponseMessage response
                = await this.HttpClient.GetAsync(UrlBuilder.BuildEndpoint(controller, id));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<TObject>();;
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

            return await response.Content.ReadAsAsync<TObject>(new List<MediaTypeFormatter>
            {
                new JsonMediaTypeFormatter(),
                new XmlMediaTypeFormatter()
            });
        }

        public async Task<TObject> Put<TObject>(TObject data, int id)
        {
            string controller = typeof(TObject).Name;

            HttpResponseMessage response = await this.HttpClient.PutAsJsonAsync(UrlBuilder.BuildEndpoint(controller, id), data);

            return await response.Content.ReadAsAsync<TObject>();
        }

        public async System.Threading.Tasks.Task Delete<TObject>(TObject data, int id)
        {
            string controller = typeof(TObject).Name;

            HttpResponseMessage response = await this.HttpClient.DeleteAsync(UrlBuilder.BuildEndpoint(controller, id));
        }
    }
}
namespace TaskManager.WPF.Services
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using TaskManager.WPF.Exceptions;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Models.BindingModels;

    public class HttpDataService
    {
        public HttpDataService()
        {
            this.HttpClient = new HttpClient();

            if (LoggedUser.Instance.User != null)
            {
                this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoggedUser.Instance.User.Bearer);
            }
        }

        private HttpClient HttpClient { get; set; }

        public async Task TestServerConnection()
        {
            HttpResponseMessage response = await this.HttpClient.GetAsync(UrlBuilder.BuildEndpoint("Test"));

            if (!response.IsSuccessStatusCode)
            {
                throw new InternalServerErrorException("Brak połączenia z serwerem!");
            }
        }

        public async Task<WPFApplicationUser> Login(LoginBindingModel login)
        {
            HttpResponseMessage response = await this.HttpClient.PostAsJsonAsync(UrlBuilder.BuildEndpoint("Account", "Login"), login);

            WPFApplicationUser account = JsonConvert.DeserializeObject<WPFApplicationUser>(await response.Content.ReadAsStringAsync());

            if (response.IsSuccessStatusCode)
            {
                return account;
            }
            else
            {
                throw new ExternalLoginException("Błędne dane logowania!");
            }
        }

        public async Task Register(RegistrationBindingModel account)
        {
            HttpResponseMessage response = await this.HttpClient.PostAsJsonAsync(UrlBuilder.BuildEndpoint("Account", "Register"), account);

            if (!response.IsSuccessStatusCode)
            {
                throw new RegistrationException("Błąd serwera, sprawdź formularz!");
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
                return default;
            }
        }

        public async Task<TObject> Get<TObject>(int id)
        {
            string controller = typeof(TObject).Name;

            HttpResponseMessage response
                = await this.HttpClient.GetAsync(UrlBuilder.BuildEndpoint(controller, id));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<TObject>();
            }
            else
            {
                return default;
            }
        }

        public async Task<TObject> Get<TObject>(string id)
        {
            string controller = typeof(TObject).Name;

            HttpResponseMessage response
                = await this.HttpClient.GetAsync(UrlBuilder.BuildEndpoint(controller, id));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<TObject>();
            }
            else
            {
                return default;
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

        public async Task<TObject> Put<TObject>(TObject data, params string[] routes)
        {
            string controller = typeof(TObject).Name;

            HttpResponseMessage response = await this.HttpClient.PutAsJsonAsync(UrlBuilder.BuildEndpoint(controller, routes), data);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<TObject>();
            }
            else
            {
                throw new InternalServerErrorException("Błąd serwera! Pobieranie danych...");
            }
        }

        public async Task Delete<TObject>(TObject data, int id)
        {
            string controller = typeof(TObject).Name;

            HttpResponseMessage response = await this.HttpClient.DeleteAsync(UrlBuilder.BuildEndpoint(controller, id));

            if (!response.IsSuccessStatusCode)
            {
                throw new InternalServerErrorException("Błąd serwera! Pobieranie danych...");
            }
        }
    }
}
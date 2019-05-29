namespace TaskManager.WPF.Services
{
    using System.Collections.ObjectModel;
    using Microsoft.AspNetCore.SignalR.Client;

    public class HubService
    {
        public static HubService Instance { get; } = new HubService();

        public ObservableCollection<string> Notifications { get; set; }

        public async void Initialize()
        {
            this.Notifications = new ObservableCollection<string>();

            var hubConnection = new HubConnectionBuilder()
                .WithUrl(UrlBuilder.BuildEndpoint("Notifications"))
                .Build();

            hubConnection.On<string>("ReciveServerUpdate", message =>
            {
                //todo
            });

            await hubConnection.StartAsync();
        }
    }
}

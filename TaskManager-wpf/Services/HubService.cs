namespace TaskManager.WPF.Services
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Microsoft.AspNet.SignalR.Client;

    public class HubService
    {
        public static HubService Instance { get; } = new HubService();

        public ObservableCollection<string> Notifications { get; set; }

        public async void Initialized()
        {
            this.Notifications = new ObservableCollection<string>();

            var queryStrings = new Dictionary<string, string>
            {
                { "group", "allUpdates" }
            };

            var hubConnection = new HubConnection(UrlBuilder.BuildEndpoint("Notifications"), queryStrings);
            var hubProxy = hubConnection.CreateHubProxy("NotificationsHub");

            hubProxy.On<string>("ReciveServerUpdate", update =>
            {
                //todo
            });

            await hubConnection.Start();
        }
    }
}

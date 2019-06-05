namespace TaskManager.WPF.Services
{
    using Microsoft.AspNetCore.SignalR.Client;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.ViewModels;

    public class NotificationsHubService
    {
        private NotificationsViewModel vm;

        public static NotificationsHubService Instance { get; } = new NotificationsHubService();

        public void SetReferenceToViewModel(NotificationsViewModel notificationsViewModel)
        {
            this.vm = notificationsViewModel;

            this.vm.Notifications = Repository.Instance.NotificationsMessages;
            this.vm.NotifyOfPropertyChange(() => this.vm.Notifications);
        }

        public void SetViewModelToNull() => this.vm = null;

        public async void Initialize()
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(UrlBuilder.BuildEndpoint("Notifications"))
                .Build();

            hubConnection.On<string>("ReciveServerUpdate", async message =>
            {
                Repository.Instance.NotificationsMessages.Add(message);
                await Repository.Instance.FetchUpdates();

                if (this.vm != null)
                {
                    this.vm.NotifyOfPropertyChange(() => this.vm.Notifications);
                }
            });

            await hubConnection.StartAsync();
        }
    }
}

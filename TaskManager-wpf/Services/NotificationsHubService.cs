namespace TaskManager.WPF.Services
{
    using Caliburn.Micro;
    using Microsoft.AspNetCore.SignalR.Client;
    using TaskManager.WPF.ViewModels;

    public class NotificationsHubService
    {
        private NotificationsViewModel vm;

        public static NotificationsHubService Instance { get; } = new NotificationsHubService();

        public BindableCollection<string> Notifications { get; set; }

        public void SetReferenceToViewModel(NotificationsViewModel notificationsViewModel)
        {
            this.vm = notificationsViewModel;

            this.vm.Notifications = this.Notifications;
            this.vm.NotifyOfPropertyChange(() => this.vm.Notifications);
        }

        public void SetViewModelToNull() => this.vm = null;

        public async void Initialize()
        {
            this.Notifications = new BindableCollection<string>();

            var hubConnection = new HubConnectionBuilder()
                .WithUrl(UrlBuilder.BuildEndpoint("Notifications"))
                .Build();

            hubConnection.On<string>("ReciveServerUpdate", message =>
            {
                this.Notifications.Add(message);

                if (this.vm != null)
                {
                    this.vm.NotifyOfPropertyChange(() => this.vm.Notifications);
                }
            });

            await hubConnection.StartAsync();
        }
    }
}

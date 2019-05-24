namespace TaskManager.WebApi.Hubs
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;

    public class NotificationsHub : Hub
    {
        public async Task GetUpdateForServer(string call)
        {
            await this.Clients.Caller.SendAsync("ReciveServerUpdate", call);
        }
    }
}

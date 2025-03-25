using Microsoft.AspNetCore.SignalR;

namespace WebApplication1.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task RegisterAsOwner()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Owners");
        }
    }
}

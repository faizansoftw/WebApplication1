using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Hubs;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class PlanExpirationChecker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHubContext<NotificationHub> _hubContext;

        public PlanExpirationChecker(IServiceProvider serviceProvider, IHubContext<NotificationHub> hubContext)
        {
            _serviceProvider = serviceProvider;
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<PostgresContext>();
                    var thresholdDate = DateTime.UtcNow.AddDays(7);
                    var clients = await context.Clients
                        .Where(c => c.EndDate <= thresholdDate && c.EndDate > DateTime.UtcNow)
                        .ToListAsync();

                    foreach (var client in clients)
                    {
                        var message = $"Client {client.FullName}'s plan is expiring on {client.EndDate:yyyy-MM-dd}";
                        var notification = new Notification
                        {
                            ClientId = client.Id,
                            Message = message,
                            CreatedAt = DateTime.UtcNow
                        };

                        context.Notifications.Add(notification);
                        await context.SaveChangesAsync();

                        // Send to owners group
                        await _hubContext.Clients.Group("Owners").SendAsync("ReceiveNotification", message);
                    }
                }

                // Check daily
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }
    }
}
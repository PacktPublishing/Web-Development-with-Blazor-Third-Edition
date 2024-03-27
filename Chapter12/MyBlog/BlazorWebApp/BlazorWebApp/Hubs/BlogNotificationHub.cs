using Data.Models;
using Microsoft.AspNetCore.SignalR;
namespace BlazorWebApp.Hubs;
public class BlogNotificationHub : Hub
{
    public async Task SendNotification(BlogPost post)
    {
        await Clients.All.SendAsync("BlogPostChanged", post);
    }
}

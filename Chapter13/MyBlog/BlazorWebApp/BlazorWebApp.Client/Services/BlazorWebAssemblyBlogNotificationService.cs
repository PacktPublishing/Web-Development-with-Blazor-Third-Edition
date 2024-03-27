using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Data.Models;
using SharedComponents.Interfaces;

namespace BlazorWebApp.Client.Services;

public class BlazorWebAssemblyBlogNotificationService : IBlogNotificationService, IAsyncDisposable
{
    public BlazorWebAssemblyBlogNotificationService(NavigationManager navigationManager)
    {
        _hubConnection = new HubConnectionBuilder()
        .WithUrl(navigationManager.ToAbsoluteUri("/BlogNotificationHub"))
        .Build();
        _hubConnection.On<BlogPost>("BlogPostChanged", (post) =>
        {
            BlogPostChanged?.Invoke(post);
        });
        _hubConnection.StartAsync();
    }
    private readonly HubConnection _hubConnection;
    public event Action<BlogPost>? BlogPostChanged;

    public async Task SendNotification(BlogPost post)
    {
        await _hubConnection.SendAsync("SendNotification", post);
    }
    public async ValueTask DisposeAsync()
    {
        await _hubConnection.DisposeAsync();
    }
}


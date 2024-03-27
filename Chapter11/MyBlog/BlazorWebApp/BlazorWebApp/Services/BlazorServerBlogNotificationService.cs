using SharedComponents.Interfaces;
using Data.Models;
namespace BlazorServer.Services;
public class BlazorServerBlogNotificationService : IBlogNotificationService
{
    public event Action<BlogPost>? BlogPostChanged;
    public Task SendNotification(BlogPost post)
    {
        BlogPostChanged?.Invoke(post);
        return Task.CompletedTask;
    }
}

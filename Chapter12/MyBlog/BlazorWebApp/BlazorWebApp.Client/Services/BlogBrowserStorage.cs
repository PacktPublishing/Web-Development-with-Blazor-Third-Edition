using Blazored.SessionStorage;
using SharedComponents.Interfaces;
namespace BlazorWebApp.Client.Services;
public class BlogBrowserStorage : IBrowserStorage
{
    ISessionStorageService Storage { get; set; }
    public BlogBrowserStorage(ISessionStorageService storage)
    {
        Storage = storage;
    }
    public async Task DeleteAsync(string key)
    {
        await Storage.RemoveItemAsync(key);
    }
    public async Task<T?> GetAsync<T>(string key)
    {
        return await Storage.GetItemAsync<T>(key);
    }
    public async Task SetAsync(string key, object value)
    {
        await Storage.SetItemAsync(key, value);
    }
}

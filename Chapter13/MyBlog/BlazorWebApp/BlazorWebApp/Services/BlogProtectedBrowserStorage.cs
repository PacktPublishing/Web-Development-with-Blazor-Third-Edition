namespace BlazorWebApp.Services;

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using SharedComponents.Interfaces;


public class BlogProtectedBrowserStorage : IBrowserStorage
{
    ProtectedSessionStorage Storage { get; set; }
    public BlogProtectedBrowserStorage(ProtectedSessionStorage storage)
    {
        Storage = storage;
    }
    public async Task DeleteAsync(string key)
    {
        await Storage.DeleteAsync(key);
    }
    public async Task<T?> GetAsync<T>(string key)
    {
        var value = await Storage.GetAsync<T>(key);
        if (value.Success)
        {
            return value.Value;
        }
        else
        {
            return default(T);
        }
    }
    public async Task SetAsync(string key, object value)
    {
        await Storage.SetAsync(key, value);
    }
}

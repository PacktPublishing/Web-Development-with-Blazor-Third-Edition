namespace SharedComponents.Interfaces;
public interface IBrowserStorage
{
    Task<T?> GetAsync<T>(string key);
    Task SetAsync(string key, object value);
    Task DeleteAsync(string key);
}

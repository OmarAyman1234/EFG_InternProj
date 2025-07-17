namespace OrderAPI.Application.Interfaces
{
    public interface ICachingService
    {
        Task<string?> GetStringAsync(string key);
        Task SetStringAsync(string key, string value, TimeSpan? absoluteExpire = null, TimeSpan? slidingExpire = null);
    }
}
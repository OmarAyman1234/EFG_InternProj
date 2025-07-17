using Microsoft.Extensions.Caching.Distributed;
using OrderAPI.Application.Interfaces;

namespace OrderAPI.Infrastructure.Services
{
    public class RedisService : ICachingService
    {
        private readonly IDistributedCache _cache;
        public RedisService(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task<string?> GetStringAsync(string key)
        {
            return await _cache.GetStringAsync(key);
        }
        public async Task SetStringAsync(string key, string value, TimeSpan? absoluteExpire = null, TimeSpan? slidingExpire = null)
        {
            var options = new DistributedCacheEntryOptions();
            if (absoluteExpire.HasValue)
                options.AbsoluteExpirationRelativeToNow = absoluteExpire;
            if (slidingExpire.HasValue)
                options.SlidingExpiration = slidingExpire;
            await _cache.SetStringAsync(key, value, options);
        }
    }
} 
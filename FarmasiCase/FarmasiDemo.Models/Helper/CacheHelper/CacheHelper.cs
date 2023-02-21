using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmasiDemo.Models.Helper.CacheHelper
{
    public class CacheHelper : ICacheHelper
    {
        IDistributedCache _distributedCache;
        private readonly int ExpirationTime=7;
        public CacheHelper(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public string GetAsync(string key)
        {
            var result=_distributedCache.GetAsync(key);
            if(result.Result!=null)
            {
                return Encoding.UTF8.GetString(result.Result);
            }
            else{
                return null;
            }
        }

        public void Remove(string key)
        {
            _distributedCache.Remove(key);
        }

        public void SetAsync(string key, string value, DistributedCacheEntryOptions options = null)
        {
            if (options == null)
            {
                options = new DistributedCacheEntryOptions();
                options.SlidingExpiration = TimeSpan.FromDays(ExpirationTime);//7 gün sonra uçar
                _distributedCache.SetAsync(key, Encoding.UTF8.GetBytes(value));
            }
        }
    }
}

using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmasiDemo.Models.Helper.CacheHelper
{
    public interface ICacheHelper
    {
        public void SetAsync(string key,string value, DistributedCacheEntryOptions options=null);
        public string GetAsync(string key);
        public void Remove(string key);
    }
}

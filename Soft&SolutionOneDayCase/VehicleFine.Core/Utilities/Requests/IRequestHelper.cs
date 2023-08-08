using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFine.Core.Utilities.Requests
{
    public interface IRequestHelper
    {

        /* Web Client */
        public string Get(string url);
        public string GetByToken(string url, string token);
        public Task<string> GetByTokenAsync(string url, string token);


        /* Http Client */

        public HttpResponseMessage Get(string url, string json);
        public HttpResponseMessage GetByToken(string url, string token, string json);
        public HttpResponseMessage Post(string url, string json);
        public HttpResponseMessage PostByToken(string url, string json, string token);


    }
}

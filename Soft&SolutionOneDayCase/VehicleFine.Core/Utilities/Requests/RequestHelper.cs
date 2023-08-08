using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFine.Core.Utilities.Requests
{
    public class RequestHelper : IRequestHelper
    {
        /* Web Client */
        public string Get(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    var result = client.DownloadString(url);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetByToken(string url, string token)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    client.Headers.Add("authorization", "Bearer " + token);
                    var result = client.DownloadString(url);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> GetByTokenAsync(string url, string token)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    client.Headers.Add("authorization", "Bearer " + token);
                    var result = await client.DownloadStringTaskAsync(url);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /* Http Client */

        public HttpResponseMessage Get(string url, string json)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(url),
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    };
                    var response = client.SendAsync(request).ConfigureAwait(false);
                    var responseInfo = response.GetAwaiter().GetResult();
                    return responseInfo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HttpResponseMessage GetByToken(string url, string token, string json)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(url),
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    };
                    var response = client.SendAsync(request).ConfigureAwait(false);
                    var responseInfo = response.GetAwaiter().GetResult();
                    return responseInfo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HttpResponseMessage Post(string url, string json)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(url),
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    };
                    var response = client.SendAsync(request).ConfigureAwait(false);
                    var responseInfo = response.GetAwaiter().GetResult();
                    return responseInfo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HttpResponseMessage PostByToken(string url, string json, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(url),
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    };

                    var response = client.SendAsync(request).ConfigureAwait(false);
                    var responseInfo = response.GetAwaiter().GetResult();
                    return responseInfo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

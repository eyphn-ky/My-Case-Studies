using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyboDemo.Model.Helpers
{
    public interface IRequestHelper
    {
        /* Web Client */

        /// <summary>
        /// İlgili url adresine istekte bulunur oradaki datayı string olarak getirir
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Get(string url);
        /// <summary>
        /// İlgili url adresine token ile bir istekte bulunur oradaki datayı string olarak getirir
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public string GetByToken(string url, string token);

        /* Http Client */

        /// <summary>
        /// İlgili url adresine data ile bir istekte bulunur
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(string url, string json);
        /// <summary>
        /// İlgili url adresine token ve data ile bir istekte bulunur
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public HttpResponseMessage GetByToken(string url, string token, string json);
        /// <summary>
        /// İlgili url adresine istekte bulunur ve data aktarımını sağlar
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(string url, string json);
        /// <summary>
        /// İlgili url adresine token ile bir istekte bulunur ve data aktarımını sağlar
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public HttpResponseMessage PostByToken(string url, string json, string token);
    }
}

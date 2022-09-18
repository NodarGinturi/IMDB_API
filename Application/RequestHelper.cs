using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class RequestHelper
    {
        public async static Task<T> SendHttpWebRequest<T>(string url, string method = "GET")
        {
            T result = default(T);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = method;
            request.ContentType = "application/json; charset=UTF-8";

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response != null)
                {
                    Stream responseStream = response.GetResponseStream();
                    using (var reader = new StreamReader(responseStream ?? throw new InvalidOperationException()))
                    {
                        string responseText = await reader.ReadToEndAsync();
                        result = JsonConvert.DeserializeObject<T>(responseText);
                    }
                }
            }

            return result;
        }
    }
}

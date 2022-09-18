using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comon.Extentions
{
    public static class RequestExtentions
    {
        public static async Task<string> FormatRequestBody(this HttpRequest request)
        {
            //request.EnableBuffering();
            var bodyAsText = await new System.IO.StreamReader(request.Body).ReadToEndAsync();
            request.Body.Position = 0;

            return $"REQUEST: Details: {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }
        public static async Task<string> FormatResponseBody(this HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return $"RESPONSE: Body:{text}. StatusCode {response.StatusCode}";
        }

    }
}

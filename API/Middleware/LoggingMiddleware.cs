using Comon.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggingMiddleware(RequestDelegate next,
           ILogger<LoggingMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            var initialBody = request.Body;
            try
            {
                _logger.LogInformation(await context.Request.FormatRequestBody());

                var originalBodyStream = context.Response.Body;
                using var responseBody = new MemoryStream();

                context.Response.Body = responseBody;
                await _next(context);
                _logger.LogInformation(await context.Response.FormatResponseBody());
                await responseBody.CopyToAsync(originalBodyStream);

            }
            finally
            {
                context.Request.Body = initialBody;
            }
        }
    }
}

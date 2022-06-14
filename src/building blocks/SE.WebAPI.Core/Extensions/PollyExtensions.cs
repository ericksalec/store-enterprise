using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace SE.WebAPI.Core.Extensions
{
    public static class PollyExtensions
    {
        public static AsyncRetryPolicy<HttpResponseMessage> EsperarTentar()
        {
            var retry = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(10),
                });

            return retry;
        }
    }

}

﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using SE.WebAPI.Core.Usuario;
using SE.WebApp.MVC.Extensions;

namespace SE.WebApp.MVC.Services.Handlers
{
    public class HttpClientAuthorizationDelegatingHandler : DelegatingHandler
    {
        private readonly IAspNetUser _user;

        public HttpClientAuthorizationDelegatingHandler(IAspNetUser user)
        {
            _user = user;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var autorizationHeader = _user.ObterHttpContext().Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(autorizationHeader))
            {
                request.Headers.Add("Authorization", new List<string>(){autorizationHeader});
            }

            var token = _user.ObterUserToken();

            if (token != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}

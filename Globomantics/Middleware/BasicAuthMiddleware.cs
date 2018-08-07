using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Middleware
{
    public class BasicAuthMiddleware
    {
        private RequestDelegate next;

        public BasicAuthMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderValue = authHeader.Replace("Basic", "").Trim();
                var decodedUserPwd = Encoding.UTF8.GetString(
                    Convert.FromBase64String(authHeaderValue)).Split(':');

                if (decodedUserPwd[0] == "Hello" && decodedUserPwd[1] == "World")
                {
                    await next.Invoke(context);
                    return;
                }
            }

            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}

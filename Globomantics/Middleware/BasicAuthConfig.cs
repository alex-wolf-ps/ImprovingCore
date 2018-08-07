using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Middleware
{
    public class BasicAuthConfig
    {
        public void Configure(IApplicationBuilder builder)
        {
            builder.UseMiddleware<BasicAuthMiddleware>();
        }
    }
}

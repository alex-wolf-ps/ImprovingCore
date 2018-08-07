using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Globomantics.Binders;
using Globomantics.Filters;
using Globomantics.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Globomantics
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ModelValidationFilter));
                options.ModelBinderProviders.Insert(0, new SurveyBinderProvider());
            });
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddSingleton<ILoanService, LoanService>();
            services.AddScoped<IQuoteService, QuoteService>();
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IRateService, RateService>();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

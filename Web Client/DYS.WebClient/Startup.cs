using DYS.WebClient.Extensions;
using DYS.WebClient.Filters;
using DYS.WebClient.Handler;
using DYS.WebClient.Models;
using DYS.WebClient.Services;
using DYS.WebClient.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DYS.WebClient
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
            services.Configure<ClientSettings>(Configuration.GetSection("ClientSettings"));
            services.Configure<ServiceApiSettings>(Configuration.GetSection("ServiceApiSettings"));
            services.AddScoped<ResourceOwnerPasswordTokenHandler>();
            var serviceApiSettings = Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
            services.AddHttpContextAccessor();
            services.AddHttpClientServices(Configuration);

            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ParameterFilterAttribute>();
            services.AddScoped<ISharedIdentityService, SharedIdentityService>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
            {
                opt.LoginPath = "/home/index";
                opt.ExpireTimeSpan = TimeSpan.FromHours(1);
                opt.SlidingExpiration = true;
                opt.Cookie.Name = "dyswebcookie";
                opt.AccessDeniedPath = "/home/AccessDenied";
            });
            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            }); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

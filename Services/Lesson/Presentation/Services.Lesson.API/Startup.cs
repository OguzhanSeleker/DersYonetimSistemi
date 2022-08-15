using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services.Lesson.API.Filters;
using Services.Lesson.API.Middlewares;
using Services.Lesson.Infrastructure;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace Services.Lesson.API
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
            var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Authority = Configuration["IdentityServerURL"];
                options.Audience = "resource_lesson";
                options.RequireHttpsMetadata = false;
            });

            services.Configure<Models.RabbitMqSettings>(Configuration.GetSection("RabbitMqSettings"));
            var rabbitmqsettings = Configuration.GetSection("RabbitMqSettings").Get<Models.RabbitMqSettings>();
            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri(rabbitmqsettings.RabbitMqRootUri), h =>
                    {
                        h.Username(rabbitmqsettings.RabbitMqUsername);
                        h.Password(rabbitmqsettings.RabbitMqPassword);
                    });
                }));
            });
            services.AddHttpContextAccessor();
            //services.AddMassTransitHostedService();
            services.AddInfraServices(Configuration);
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ParameterFilterAttribute>();
            services.AddScoped<HttpResponseExceptionFilter>();
            services.AddControllers(pt =>
            {
                pt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Services.Lesson.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Services.Lesson.API v1"));
            }
            //app.UseMiddleware<RequestResponseLoggingMiddleware>();
            //app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseLessonRequestLogging();
            app.UseRouting();
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

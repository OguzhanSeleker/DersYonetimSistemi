using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.RabbitMQ.Consumer.Consumers;
using Services.RabbitMQ.Consumer.Services;
using SharedLibrary.Services;
using System;
using System.Net.Http;

namespace Services.RabbitMQ.Consumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<ClientSettings>(hostContext.Configuration.GetSection("ClientSettings"));
                    services.Configure<ServiceApiSettings>(hostContext.Configuration.GetSection("ServiceApiSettings"));
                    //services.AddScoped<ResourceOwnerPasswordTokenHandler>();
                    //services.AddScoped<BearerTokenHandler>();
                    services.AddScoped<ISharedIdentityService, SharedIdentityService>();
                    services.AddScoped<IIdentityService, IdentityService>();
                    services.AddHttpContextAccessor();
                    services.Configure<RabbitMqSettings>(hostContext.Configuration.GetSection("RabbitMqSettings"));
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<CourseCreatedConsumer>();

                        x.UsingRabbitMq((config, cfg) =>
                        {
                            cfg.Host(new Uri(hostContext.Configuration.GetSection("RabbitMqSettings")["RabbitMqRootUri"]), host =>
                            {
                                host.Username(hostContext.Configuration.GetSection("RabbitMqSettings")["RabbitMqUsername"]);
                                host.Password(hostContext.Configuration.GetSection("RabbitMqSettings")["RabbitMqPassword"]);
                            });

                            cfg.ReceiveEndpoint("course-created-queue", e =>
                            {
                                 e.ConfigureConsumer<CourseCreatedConsumer>(config);
                            });
                        });
                    });
                    //services.AddHostedService<Worker>();
                });
    }
}

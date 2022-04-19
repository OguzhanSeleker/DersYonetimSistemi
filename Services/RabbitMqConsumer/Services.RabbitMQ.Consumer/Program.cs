using MassTransit;  
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Services.RabbitMQ.Consumer.Consumers;
using SharedLibrary.Services;
using System;
using System.Configuration;
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
                    var serviceApiSettings = hostContext.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
                    services.AddScoped<BearerTokenHandler>();
                    services.AddHttpContextAccessor();
                    services.Configure<RabbitMqSettings>(hostContext.Configuration.GetSection("RabbitMqSettings"));
                    var rabbitMqSettings = hostContext.Configuration.GetSection("RabbitMqSettings").Get<RabbitMqSettings>();
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<CourseCreatedConsumer>();
                        x.AddConsumer<CourseUserCreatedConsumer>();
                        x.UsingRabbitMq((config, cfg) =>
                        {
                            cfg.Host(new Uri(rabbitMqSettings.RabbitMqRootUri), host =>
                            {
                                host.Username(rabbitMqSettings.RabbitMqUsername);
                                host.Password(rabbitMqSettings.RabbitMqPassword);
                            });

                            cfg.ReceiveEndpoint(rabbitMqSettings.RabbitMqCourseCreatedQueue, e =>
                            {
                                e.ConfigureConsumer<CourseCreatedConsumer>(config);
                                e.UseMessageRetry(i => i.Immediate(5));


                            });
                            cfg.ReceiveEndpoint(rabbitMqSettings.RabbitMqCourseUserCreatedQueue, e =>
                            {
                                e.ConfigureConsumer<CourseUserCreatedConsumer>(config);
                                e.UseMessageRetry(i => i.Immediate(5));
                            });
                        });
                    });
                    services.AddOptions<MassTransitHostOptions>()
                        .Configure(options =>
                        {
                            // if specified, waits until the bus is started before
                            // returning from IHostedService.StartAsync
                            // default is false
                            options.WaitUntilStarted = true;

                            // if specified, limits the wait time when starting the bus
                            options.StartTimeout = TimeSpan.FromSeconds(10);

                            // if specified, limits the wait time when stopping the bus
                            options.StopTimeout = TimeSpan.FromSeconds(30);
                        });
                    //services.AddHostedService<Worker>();
                });
    }
}

// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using DYS.AuthServer.Data;
using DYS.AuthServer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Linq;

namespace DYS.AuthServer
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Code)
                .CreateLogger();

            try
            {
                var host = CreateHostBuilder(args).Build();
                using (var scope = host.Services.CreateScope())
                {
                    var serviceProvider = scope.ServiceProvider;
                    var applicationDbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
                    applicationDbContext.Database.Migrate();
                    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    if (!userManager.Users.Any())
                    {
                        userManager.CreateAsync(new ApplicationUser { UserName = "ogrenci22", Email = "ogrenci22@itu.edu.tr", FirstName = "İsimÖğrenci", LastName = "SoyisimÖğrenci" }, "Admin123*").Wait();
                        userManager.CreateAsync(new ApplicationUser { UserName = "egitmen22", Email = "egitmen22@itu.edu.tr", FirstName = "İsimEğitmen", LastName = "SoyisimEğitmen" }, "Admin123*").Wait();
                        userManager.CreateAsync(new ApplicationUser { UserName = "seleker17", Email = "seleker17@itu.edu.tr", FirstName = "Oğuzhan", LastName = "Seleker" }, "Admin123*").Wait();
                    }
                    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    if (!roleManager.Roles.Any())
                    {
                        roleManager.CreateAsync(new IdentityRole { Name = "Teacher" }).Wait();
                        roleManager.CreateAsync(new IdentityRole { Name = "Student" }).Wait();
                        roleManager.CreateAsync(new IdentityRole { Name = "Asistant" }).Wait();
                        userManager.AddToRoleAsync(userManager.FindByNameAsync("ogrenci22").Result, "Student").Wait();
                        userManager.AddToRoleAsync(userManager.FindByNameAsync("egitmen22").Result, "Teacher").Wait();
                        userManager.AddToRoleAsync(userManager.FindByNameAsync("seleker17").Result, "Admin").Wait();
                        roleManager.CreateAsync(new IdentityRole { Name = "Admin" }).Wait();
                    }
                }
                Log.Information("Starting host...");
                host.Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly.");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
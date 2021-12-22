using Microsoft.Extensions.Configuration;
using Lesson.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson.Domain.Interfaces;
using Lesson.API.Services;
using Lesson.Infrastructure.Repositories;

namespace Lesson.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext with Scoped lifetime
            services.AddDbContext<LessonDbContext>(options =>
            {
                services.AddDbContext<LessonDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PostgreSql"), conf =>
                {
                    conf.MigrationsAssembly("Lesson.API");
                }));
                
            });
            
            services.AddScoped<Func<LessonDbContext>>((provider) => () => provider.GetService<LessonDbContext>());
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<ILessonRepository, LessonRepository>()
                .AddScoped<ILessonCodeRepository, LessonCodeRepository>();
                
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ILessonService, LessonService>()
                .AddAutoMapper(typeof(Startup).Assembly);
        }
    }
}

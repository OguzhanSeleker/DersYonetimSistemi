using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Lesson.Application.Repositories;
using Services.Lesson.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Lesson.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LessonServiceDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
            services.AddScoped<ILessonWriteRepository, LessonWriteRepository>();
            services.AddScoped<ILessonReadRepository, LessonReadRepository>();
            services.AddScoped<ICourseReadRepository, CourseReadRepository>();
            services.AddScoped<ICourseWriteRepository, CourseWriteRepository>();
            services.AddScoped<ICourseUserReadRepository, CourseUserReadRepository>();
            services.AddScoped<ICourseUserWriteRepository, CourseUserWriteRepository>();
            services.AddScoped<IRoleInCourseReadRepository, RoleInCourseReadRepository>();
            services.AddScoped<IRoleInCourseWriteRepository, RoleInCourseWriteRepository>();
            services.AddScoped<ITimePlaceReadRepository, TimePlaceReadRepository>();
            services.AddScoped<ITimePlaceWriteRepository, TimePlaceWriteRepository>();
        }
    }
}

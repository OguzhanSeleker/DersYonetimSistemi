using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Attendance.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AttendanceDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));

        }
    }
}

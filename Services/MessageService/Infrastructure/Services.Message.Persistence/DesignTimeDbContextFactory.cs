using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Services.Message.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Message.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MessageServiceDbContext>
    {
        public MessageServiceDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MessageServiceDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql("User ID=admin;Password=Admin123*;Server=localhost;Port=5433;Database=messageDb;Integrated Security=true;pooling=true");
            return new(dbContextOptionsBuilder.Options);
        }
    }
}

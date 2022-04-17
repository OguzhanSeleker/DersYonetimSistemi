using Microsoft.EntityFrameworkCore;
using Services.Survey.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Survey.Application.Repositories.BaseRepositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }

    }
}

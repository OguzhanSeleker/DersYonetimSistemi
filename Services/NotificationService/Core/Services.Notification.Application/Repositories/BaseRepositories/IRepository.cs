
using Microsoft.EntityFrameworkCore;
using Services.Notification.Domain.Entities.Common;

namespace Services.Notification.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}

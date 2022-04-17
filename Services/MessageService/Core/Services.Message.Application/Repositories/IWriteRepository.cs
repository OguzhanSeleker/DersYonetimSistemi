using Services.Message.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Message.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> modelList);
        Task RemoveAsync(string id);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}

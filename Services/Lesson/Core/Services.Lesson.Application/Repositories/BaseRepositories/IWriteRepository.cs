
using Services.Lesson.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Lesson.Application.Repositories
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

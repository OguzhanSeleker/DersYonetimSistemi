﻿using MongoDB.Driver;
using Services.Homework.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Homework.Application.Services.BaseRepository
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        IMongoCollection<T> Collection { get; }
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(string Id, bool tracking = true);
        Task<T> AddAsync(T model);
        Task RemoveAsync(string id);
        bool Update(T model);
    }
}

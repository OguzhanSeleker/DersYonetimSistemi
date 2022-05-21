using MongoDB.Driver;
using Services.Homework.Application.Services;
using Services.Homework.Domain.Entities;
using Services.Homework.Infrastructure.DbSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Homework.Infrastructure.Services
{
    public class HomeworkMetadataService : IHomeworkMetadataService
    {
        public IMongoCollection<HomeworkMetadata> Collection { get; private set; }
        public HomeworkMetadataService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            Collection = database.GetCollection<HomeworkMetadata>(databaseSettings.HomeworkMetadataCollectionName);
        }
        public Task<HomeworkMetadata> AddAsync(HomeworkMetadata model)
        {
            
        }

        public Task<bool> AddRangeAsync(List<HomeworkMetadata> modelList)
        {
            
        }

        public IQueryable<HomeworkMetadata> GetAll(bool tracking = true)
        {
            
        }

        public Task<HomeworkMetadata> GetByIdAsync(string Id, bool tracking = true)
        {
            
        }

        public Task<HomeworkMetadata> GetSingleAsync(Expression<Func<HomeworkMetadata, bool>> method, bool tracking = true)
        {
            
        }

        public IQueryable<HomeworkMetadata> GetWhere(Expression<Func<HomeworkMetadata, bool>> method, bool tracking = true)
        {
            
        }

        public Task RemoveAsync(string id)
        {
            
        }

        public bool Update(HomeworkMetadata model)
        {
            
        }
    }
}

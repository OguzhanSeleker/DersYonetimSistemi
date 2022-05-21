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
    public class HomeworkInformationService : IHomeworkInformationService
    {
        public IMongoCollection<HomeworkInformation> Collection { get; private set; }

        public HomeworkInformationService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            Collection = database.GetCollection<HomeworkInformation>(databaseSettings.HomeworkInformationCollectionName);
        }

        public async Task<HomeworkInformation> AddAsync(HomeworkInformation model)
        {
            model.UploadDate = DateTime.Now;
            model.Deleted = false;
            await Collection.InsertOneAsync(model);
            return model;
        }


        public async Task<HomeworkInformation> GetByIdAsync(string Id, bool tracking = true)
        {
            
        }

        public Task<HomeworkInformation> GetSingleAsync(Expression<Func<HomeworkInformation, bool>> method, bool tracking = true)
        {
            
        }

        public IQueryable<HomeworkInformation> GetWhere(Expression<Func<HomeworkInformation, bool>> method, bool tracking = true)
        {
            
        }

        public Task RemoveAsync(string id)
        {
            
        }

        public bool Update(HomeworkInformation model)
        {
            
        }
    }
}

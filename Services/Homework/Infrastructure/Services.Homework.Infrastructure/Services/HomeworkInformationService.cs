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
            var entity = await Collection.Find(i => i.Id == Id && !i.Deleted).FirstOrDefaultAsync();
            if (entity == null) return null;
            return entity;
        }


        public async Task RemoveAsync(string id)
        {
            var entity = await Collection
                .Find(i => i.Id == id && !i.Deleted)
                .FirstOrDefaultAsync();
            if (entity == null) throw new Exception("Not Found");
            var save = await Collection.UpdateOneAsync(Builders<HomeworkInformation>.Filter.Eq(i => i.Id, entity.Id), Builders<HomeworkInformation>.Update.Set(i => i.Deleted, true));
        }

        public bool Update(HomeworkInformation model)
        {
            var filter = Builders<HomeworkInformation>.Filter.Eq(i => i.Id, model.Id);
            var res = Collection.ReplaceOne(filter, model);
            return res.IsModifiedCountAvailable;
        }

        public async Task<HomeworkInformation> GetByCourseId(string courseId)
        {
            var entity = await Collection.Find(i => i.CourseId == courseId && !i.Deleted).FirstOrDefaultAsync();
            if (entity == null) return null;
            return entity;
        }
    }
}

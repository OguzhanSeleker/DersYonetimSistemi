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
        public async Task<HomeworkMetadata> AddAsync(HomeworkMetadata model)
        {
            model.UploadDate = DateTime.Now;
            model.Deleted = false;
            await Collection.InsertOneAsync(model);
            return model;
        }
   


        public async Task<HomeworkMetadata> GetByIdAsync(string Id, bool tracking = true)
        {
            var entity = await Collection.Find(i => i.Id == Id && !i.Deleted).FirstOrDefaultAsync();
            if (entity == null) throw new Exception("Not Found");
            return entity;
        }

       

        public async Task RemoveAsync(string id)
        {
            var entity = await Collection
                .Find(i => i.Id == id && !i.Deleted)
                .FirstOrDefaultAsync();
            if (entity == null) throw new Exception("Not Found");
            var save = await Collection.UpdateOneAsync(Builders<HomeworkMetadata>.Filter.Eq(i => i.Id, entity.Id), Builders<HomeworkMetadata>.Update.Set(i => i.Deleted, true));
        }

        public bool Update(HomeworkMetadata model)
        {
            var filter = Builders<HomeworkMetadata>.Filter.Eq(i => i.Id, model.Id);
            var res = Collection.ReplaceOne(filter, model);
            return res.IsModifiedCountAvailable;
        }

        public async Task<HomeworkMetadata> GetHomeworkMetadataByHomeworkInformationId(string homeworkInformationId)
        {
            var entity = await Collection.Find(i => i.HomeworkInformationId == homeworkInformationId && !i.Deleted).FirstOrDefaultAsync();
            if (entity == null) throw new Exception("Not Found");
            return entity;
        }
    }
}

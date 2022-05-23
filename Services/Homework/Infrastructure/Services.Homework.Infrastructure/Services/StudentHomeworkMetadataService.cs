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
    public class StudentHomeworkMetadataService : IStudentHomeworkMetadataService
    {
        public IMongoCollection<StudentHomeworkMetadata> Collection { get; private set; }

        public StudentHomeworkMetadataService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            Collection = database.GetCollection<StudentHomeworkMetadata>(databaseSettings.StudentHomeworkMetadataCollectionName);
        }
        public async Task<StudentHomeworkMetadata> AddAsync(StudentHomeworkMetadata model)
        {
            model.UploadDate = DateTime.Now;
            model.Deleted = false;
            await Collection.InsertOneAsync(model);
            return model;
        }


        public async Task<StudentHomeworkMetadata> GetByIdAsync(string Id, bool tracking = true)
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
            var save = await Collection.UpdateOneAsync(Builders<StudentHomeworkMetadata>.Filter.Eq(i => i.Id, entity.Id), Builders<StudentHomeworkMetadata>.Update.Set(i => i.Deleted, true));
        }

        public bool Update(StudentHomeworkMetadata model)
        {
            var filter = Builders<StudentHomeworkMetadata>.Filter.Eq(i => i.Id, model.Id);
            var res = Collection.ReplaceOne(filter, model);
            return res.IsModifiedCountAvailable;
        }

        public async Task<List<StudentHomeworkMetadata>> GetStudentHomeworkMetadataByHomeworkMetadataId(string homeworkMetadataId)
        {
            var entity = await Collection.Find(i => i.HomeworkInformationId == homeworkMetadataId && !i.Deleted).ToListAsync();
            if (entity == null) throw new Exception("Not Found");
            return entity;
        }
    }
}

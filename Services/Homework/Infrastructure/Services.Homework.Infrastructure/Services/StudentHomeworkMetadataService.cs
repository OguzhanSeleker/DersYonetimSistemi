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
        public Task<StudentHomeworkMetadata> AddAsync(StudentHomeworkMetadata model)
        {
            
        }

        public Task<bool> AddRangeAsync(List<StudentHomeworkMetadata> modelList)
        {
            
        }

        public IQueryable<StudentHomeworkMetadata> GetAll(bool tracking = true)
        {
            
        }

        public Task<StudentHomeworkMetadata> GetByIdAsync(string Id, bool tracking = true)
        {
            
        }

        public Task<StudentHomeworkMetadata> GetSingleAsync(Expression<Func<StudentHomeworkMetadata, bool>> method, bool tracking = true)
        {
            
        }

        public IQueryable<StudentHomeworkMetadata> GetWhere(Expression<Func<StudentHomeworkMetadata, bool>> method, bool tracking = true)
        {
            
        }

        public Task RemoveAsync(string id)
        {
            
        }

        public bool Update(StudentHomeworkMetadata model)
        {
            
        }
    }
}

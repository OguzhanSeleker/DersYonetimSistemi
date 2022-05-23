using MongoDB.Driver;
using Services.FileSystem.Application;
using Services.FileSystem.Domain.Dtos;
using Services.FileSystem.Domain.Entities;
using Services.FileSystem.Domain.Mapping;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FileSystem.Infrastructure
{
    public class FileMetadataService : IFileMetadataService
    {
        private readonly IMongoCollection<WebFileSystem> _collection;

        public FileMetadataService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _collection = database.GetCollection<WebFileSystem>(databaseSettings.FileSystemCollectionName);
        }

        public async Task<OperationResult<GetFileSystemDto>> AddFileMetadata(AddFileSystemDto addFileSystemDto)
        {
            try
            {
                var entity = ObjectMapper.Mapper.Map<WebFileSystem>(addFileSystemDto);
                entity.CreatedDate = DateTime.Now;
                await _collection.InsertOneAsync(entity);
                return OperationResult<GetFileSystemDto>.CreatedSuccessResult(ObjectMapper.Mapper.Map<GetFileSystemDto>(entity));
            }
            catch(Exception ex)
            {
                return OperationResult<GetFileSystemDto>.CreateFailure(ex);
            }
        }

        public async Task<OperationResult<NoContent>> DeleteFileMetadata(string id)
        {
            try
            {
                var entity = await _collection.Find<WebFileSystem>(i => i.Id == id && !i.Deleted).FirstAsync();
                if (entity == null) throw new Exception("Metadata Not Found");
                entity.Deleted = true;
                var save = await _collection.UpdateOneAsync(Builders<WebFileSystem>.Filter.Eq(i => i.Id,entity.Id),Builders<WebFileSystem>.Update.Set(i => i.Deleted,true));
                return save.IsModifiedCountAvailable ? OperationResult<NoContent>.NoContentSuccessResult() : throw new Exception("Could not be deleted");
            }
            catch (Exception ex)
            {
                return OperationResult<NoContent>.CreateFailure(ex);

            }
        }

        public async Task<OperationResult<GetFileSystemDto>> GetById(string id)
        {
            try
            {
                var entity = await _collection.Find(i => i.Id == id && !i.Deleted).FirstAsync();
                if (entity == null) return null;
                return OperationResult<GetFileSystemDto>.OkSuccessResult(ObjectMapper.Mapper.Map<GetFileSystemDto>(entity));
            }
            catch (Exception ex)
            {
                return OperationResult<GetFileSystemDto>.CreateFailure(ex);
            }
        }

        public async Task<OperationResult<List<GetFileSystemDto>>> GetByCourseId(string courseId)
        {
            try
            {
                var entityList = await _collection.Find(i => i.CourseId == courseId && !i.Deleted).SortByDescending(i => i.CreatedDate).ToListAsync();
                if(entityList == null) return null;
                return OperationResult<List<GetFileSystemDto>>.OkSuccessResult(ObjectMapper.Mapper.Map<List<GetFileSystemDto>>(entityList));
            }
            catch (Exception ex)
            {
                return OperationResult<List<GetFileSystemDto>>.CreateFailure(ex);
            }
        }
    }
}

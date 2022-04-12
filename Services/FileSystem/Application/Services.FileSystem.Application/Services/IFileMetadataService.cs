using Services.FileSystem.Domain.Dtos;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FileSystem.Application
{
    public interface IFileMetadataService
    {
        Task<OperationResult<GetFileSystemDto>> AddFileMetadata(AddFileSystemDto addFileSystemDto);
        Task<OperationResult<NoContent>> DeleteFileMetadata(string id);
        Task<OperationResult<List<GetFileSystemDto>>> GetByCourseId(string courseId);
        Task<OperationResult<GetFileSystemDto>> GetById(string id);
    }
}

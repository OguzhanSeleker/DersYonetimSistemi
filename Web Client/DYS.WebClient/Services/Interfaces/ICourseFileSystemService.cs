using DYS.WebClient.Models.CourseFileSystem;
using Microsoft.AspNetCore.Http;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Services.Interfaces
{
    public interface ICourseFileSystemService
    {
        Task<GetFileSystemDto> AddCourseFile(AddFileWithMetadata addFileWithMetadata);
        Task<List<GetFileSystemDto>> GetByCourseId(string courseId);
        Task<FileDto> DownloadFile(string fileId);
        Task<bool> DeleteFile(string fileId);
    }
}

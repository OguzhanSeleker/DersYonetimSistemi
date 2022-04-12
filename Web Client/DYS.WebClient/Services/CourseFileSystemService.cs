using DYS.WebClient.Models.CourseFileSystem;
using DYS.WebClient.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DYS.WebClient.Services
{
    public class CourseFileSystemService : ICourseFileSystemService
    {
        private readonly HttpClient _client;

        public CourseFileSystemService(HttpClient client)
        {
            _client = client;
        }
        public async Task<GetFileSystemDto> AddCourseFile(AddFileWithMetadata addFileWithMetadata)
        {
            var dosyaIsmi = addFileWithMetadata.FileName.Trim() + Path.GetExtension(addFileWithMetadata.File.FileName);
            using var ms = new MemoryStream();
            addFileWithMetadata.File.CopyTo(ms);
            var multipartContent = new MultipartFormDataContent();
            multipartContent.Add(new ByteArrayContent(ms.ToArray()), "File", dosyaIsmi);
            multipartContent.Add(new StringContent(addFileWithMetadata.AddFileSystemDto.CourseId.ToString()), "courseId");
            multipartContent.Add(new StringContent(addFileWithMetadata.AddFileSystemDto.CreatedBy.ToString()), "createdBy");
            multipartContent.Add(new StringContent(addFileWithMetadata.AddFileSystemDto.CourseCRN), "courseCRN");
            var response = await _client.PostAsync("FileSystems", multipartContent);
            var str = await response.Content.ReadAsStringAsync();
            var converted = JsonConvert.DeserializeObject<OperationResult<GetFileSystemDto>>(str);
            if (converted != null)
                return converted.Data;
            return null;
        }

        public async Task<bool> DeleteFile(string fileId)
        {
            var response = await _client.DeleteAsync($"FileSystems/{fileId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<FileDto> DownloadFile(string fileId)
        {
            var response = await _client.GetAsync($"FileSystems/GetById/{fileId}");
            if (response != null && response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                var converted = JsonConvert.DeserializeObject<OperationResult<GetFileSystemDto>>(str);
                if (converted != null && converted.Data != null)
                {
                    HttpClient dosyaClient = new HttpClient();
                    var fileRes = await dosyaClient.GetAsync($"http://localhost:5016/{converted.Data.Path}");
                    fileRes.EnsureSuccessStatusCode();
                    var ba = await fileRes.Content.ReadAsByteArrayAsync();
                    return new FileDto { fileByteArr =ba, DisplayName = converted.Data.DisplayFileName};
                }
                return null;
            }
            return null;
        }

        public async Task<List<GetFileSystemDto>> GetByCourseId(string courseId)
        {
            var response = await _client.GetAsync($"FileSystems/GetFileListByCourseId/{courseId}");
            var str = await response.Content.ReadAsStringAsync();
            var converted = JsonConvert.DeserializeObject<OperationResult<List<GetFileSystemDto>>>(str);
            if (converted != null && converted.Data != null)
                return converted.Data;
            return null;
        }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYS.WebClient.Models.CourseFileSystem
{
    public class AddFileWithMetadata
    {
        public AddFileSystemDto AddFileSystemDto { get; set; }
        public IFormFile File { get; set; }
        public string FileName { get; set; }
    }
}

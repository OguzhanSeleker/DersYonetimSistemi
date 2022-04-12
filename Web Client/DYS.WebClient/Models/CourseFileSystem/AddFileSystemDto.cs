using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYS.WebClient.Models.CourseFileSystem
{
    public class AddFileSystemDto
    {
        public Guid CourseId { get; set; }
        public Guid CreatedBy { get; set; }
        public string CourseCRN { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
    }
}

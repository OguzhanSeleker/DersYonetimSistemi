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
        public string CourseId { get; set; }
        public string CreatedBy { get; set; }
        public string CourseCRN { get; set; }
        public string Extension { get; set; }
        public string DisplayFileName { get; set; }
        public string FullPath { get; set; }
        public string Path { get; set; }
    }
}

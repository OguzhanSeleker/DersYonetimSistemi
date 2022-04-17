using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FileSystem.Domain.Dtos
{
    public class GetFileSystemDto : IDto
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string CourseCRN { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Extension { get; set; }
        public string FullPath { get; set; }
        public string Path { get; set; }
        public string DisplayFileName { get; set; }
        public bool Deleted { get; set; }
    }
}

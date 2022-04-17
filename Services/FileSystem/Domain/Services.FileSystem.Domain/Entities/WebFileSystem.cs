using Services.FileSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FileSystem.Domain.Entities
{
    public class WebFileSystem : BaseEntity
    {
        public string CourseId { get; set; }
        public string CourseCRN { get; set; }
        public string CreatedBy { get; set; }
        public string FullPath { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public string DisplayFileName { get; set; }
    }
}

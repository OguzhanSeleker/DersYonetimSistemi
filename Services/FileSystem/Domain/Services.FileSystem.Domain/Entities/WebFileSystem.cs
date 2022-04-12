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
        public Guid CourseId { get; set; }
        public string CourseCRN { get; set; }
        public Guid CreatedBy { get; set; }
        public string Path { get; set; }
    }
}

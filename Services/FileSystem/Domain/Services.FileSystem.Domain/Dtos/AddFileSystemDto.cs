using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FileSystem.Domain.Dtos
{
    public class AddFileSystemDto
    {
        public Guid CourseId { get; set; }
        public Guid CreatedBy { get; set; }
        public string CourseCRN { get; set; }
        public string Path { get; set; }
    }
}

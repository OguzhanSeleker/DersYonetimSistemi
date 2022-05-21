using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Homework.Domain.Dtos
{
    public class GetHomeworkMetadata
    {
        public string HomeworkInformationId { get; set; }
        public string FullPath { get; set; }
        public string ShortPath { get; set; }
        public string Extension { get; set; }
        public string DisplayName { get; set; }
        public string Id { get; set; }
        public DateTime UploadDate { get; set; }
        public string UploadBy { get; set; }
        public bool Deleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Homework.Application.Dtos
{
    public class AddHomeworkMetadata
    {
        public string HomeworkInformationId { get; set; }
        public string FullPath { get; set; }
        public string ShortPath { get; set; }
        public string Extension { get; set; }
        public string DisplayName { get; set; }
        public DateTime UploadDate { get; set; }
        public string UploadBy { get; set; }
    }
}

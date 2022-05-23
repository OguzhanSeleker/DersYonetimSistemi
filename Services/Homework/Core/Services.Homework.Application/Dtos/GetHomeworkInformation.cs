using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Homework.Application.Dtos
{
    public class GetHomeworkInformation
    {
        public string HomeworkTitle { get; set; }
        public string HomeworkDescription { get; set; }
        public string CourseId { get; set; }
        public string CourseCRN { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool Active { get; set; }
        public string Id { get; set; }
        public DateTime UploadDate { get; set; }
        public string UploadBy { get; set; }
        public bool Deleted { get; set; }
    }
}

using Services.Homework.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Homework.Domain.Entities
{
    public class HomeworkInformation : BaseEntity
    {
        public string HomeworkTitle { get; set; }
        public string HomeworkDescription { get; set; }
        public string CourseId { get; set; }
        public string CourseCRN { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool Active { get; set; }
    }
}

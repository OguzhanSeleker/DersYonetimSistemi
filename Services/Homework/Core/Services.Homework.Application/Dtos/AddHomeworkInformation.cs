using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Homework.Application.Dtos
{
    public class AddHomeworkInformation
    {
        [Required]
        public string HomeworkTitle { get; set; }
        [Required]
        public string HomeworkDescription { get; set; }
        [Required]
        public string CourseId { get; set; }
        [Required]
        public string CourseCRN { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public DateTime UploadDate { get; set; }
        [Required]
        public string UploadBy { get; set; }

    }
}

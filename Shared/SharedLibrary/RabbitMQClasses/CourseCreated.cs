using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.RabbitMQClasses
{
    public class CourseCreated
    {
        public Guid CourseId { get; set; }
        public string CourseLessonName { get; set; }
        public string CRN { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IList<CreatedTimePlaces> TimePlaces{ get; set; }

    }
}

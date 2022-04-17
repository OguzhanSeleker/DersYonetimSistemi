using Services.Lesson.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Lesson.Domain.Entities
{
    public class CourseUser : BaseEntity
    {
        [ForeignKey(nameof(Course))]

        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey(nameof(RoleInCourse))]
        public Guid RoleInCourseId { get; set; }
        public RoleInCourse RoleInCourse { get; set; }
        public Course Course { get; set; }
    }

}

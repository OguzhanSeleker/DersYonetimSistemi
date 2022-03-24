using System;

namespace DYS.WebClient.Models.Lesson
    public class QueryCourseUserDto : GetDto
    {
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleInCourseId { get; set; }

        public RoleInCourseDto RoleInCourse { get; set; }
    }
}

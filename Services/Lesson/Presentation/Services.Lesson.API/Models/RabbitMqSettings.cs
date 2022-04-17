namespace Services.Lesson.API.Models
{
    public class RabbitMqSettings
    {
        public string RabbitMqRootUri { get; set; }
        public string RabbitMqCourseCreatedQueue { get; set; }
        public string RabbitMqUsername { get; set; }
        public string RabbitMqPassword { get; set; }
        public string RabbitMqLessonServiceQueue { get; set; }
    }
}

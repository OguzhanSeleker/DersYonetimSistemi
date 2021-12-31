namespace Lesson.API.Dtos
{
    public class LessonCodeDto
    {
        public int MyProperty { get; set; }
        public string Code { get; set; }
        public string CoordinatorId { get; set; }
    }
    public class AddLessonCodeDto
    {
        public string Code { get; set; }
        public string CoordinatorId { get; set; }

    }
}

using System;

namespace Lesson.API.Dtos
{
    public class TimeDayRoomDto
    {
        public DayOfWeek DayOfWeek { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public int ClassRoomId { get; set; }
        public int LessonId { get; set; }
    }
}

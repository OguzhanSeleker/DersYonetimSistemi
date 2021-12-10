using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson.API.Dtos
{
    public class CreateLessonDto
    {
        public int LessonCodeId { get; set; }
        public string LessonName { get; set; }
        public string LessonCRN { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastAccessDate { get; set; }
        public List<LecturerDto> LecturerDtoList { get; set; }
        public List<AssistantDto> AssistantDtoList { get; set; }
        public LessonCodeDto LessonCodeDto { get; set; }
        public List<TimeDayRoomDto> TimeDayRoomDtoList{ get; set; }
        public string CreatedBy { get; set; }
    }

    public class LessonDto
    {
        public int ObjectId { get; set; }
        public int LessonCodeId { get; set; }
        public string LessonName { get; set; }
        public string LessonCRN { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastAccessDate { get; set; }
        public List<LecturerDto> LecturerDtoList { get; set; }
        public List<AssistantDto> AssistantDtoList { get; set; }
        public LessonCodeDto LessonCodeDto { get; set; }
        public List<TimeDayRoomDto> TimeDayRoomDtoList { get; set; }
        public string CreatedBy { get; set; }
    }
}

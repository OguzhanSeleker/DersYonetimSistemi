using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson.API.Dtos
{
    public class CreateLessonDto
    {
        [Required]
        public int LessonCodeId { get; set; }
        [Required]
        public string LessonName { get; set; }
        [Required]
        public string LessonCRN { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public DateTime LastAccessDate { get; set; }
        [Required]
        public List<LecturerDto> LecturerDtoList { get; set; }
        [Required]
        public List<AssistantDto> AssistantDtoList { get; set; }
        [Required]
        public LessonCodeDto LessonCodeDto { get; set; }
        [Required]
        public List<TimeDayRoomDto> TimeDayRoomDtoList{ get; set; }
        [Required]
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

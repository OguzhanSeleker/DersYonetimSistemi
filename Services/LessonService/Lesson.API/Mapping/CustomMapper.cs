using AutoMapper;
using Lesson.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson.API.Mapping
{
    public class CustomMapper : Profile
    {
        public CustomMapper()
        {
            CreateMap<Domain.Aggregates.Lesson, CreateLessonDto>().ReverseMap();
            CreateMap<Domain.Aggregates.Lesson, LessonDto>().ReverseMap();
            CreateMap<Domain.Aggregates.LessonAssistant, AssistantDto>().ReverseMap();
            CreateMap<Domain.Aggregates.LessonLecturer, LecturerDto>().ReverseMap();
            CreateMap<Domain.Aggregates.LessonStudent, StudentDto>().ReverseMap();
            CreateMap<Domain.Aggregates.TimeDayRoom, TimeDayRoomDto>().ReverseMap();
            CreateMap<Domain.Aggregates.LessonCode, LessonCodeDto>().ReverseMap();

        }
    }
}

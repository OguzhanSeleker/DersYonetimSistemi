using AutoMapper;
using Lesson.DAL.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.DAL.Concrete.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Entities.Lesson, AddLessonDto>().ReverseMap();
            CreateMap<Entities.Lesson, UpdateLessonDto>().ReverseMap();
            CreateMap<Entities.Lesson, AddAssistantToLessonDto>().ReverseMap();
            CreateMap<Entities.Lesson, AddStudentsToLessonDto>().ReverseMap();
            CreateMap<Entities.Lesson, LessonDto>().ReverseMap();
            CreateMap<Entities.Lesson, GetLessonDto>().ReverseMap();
        }
    }
}

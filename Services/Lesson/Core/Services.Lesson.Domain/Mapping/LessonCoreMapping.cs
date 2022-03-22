using AutoMapper;
using Services.Lesson.Domain.Dtos;
using Services.Lesson.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Lesson.Domain.Mapping
{
    public class LessonCoreMapping : Profile
    {
        public LessonCoreMapping()
        {
            CreateMap<BaseEntity,GetDto>().ReverseMap();
            CreateMap<BaseEntity,InsertDto>().ReverseMap();
            CreateMap<Entities.Lesson,InsertLessonDto>().ReverseMap();
            CreateMap<Entities.Lesson,QueryLessonDto>().ReverseMap();
            CreateMap<Entities.Lesson,UpdateLessonDto>().ReverseMap();
            CreateMap<Entities.Course, InsertCourseDto>().ReverseMap();
            CreateMap<Entities.Course, QueryCourseDto>().ReverseMap();
            CreateMap<Entities.Course, UpdateCourseDto>().ReverseMap();
            CreateMap<Entities.CourseUser, InsertCourseUserDto>().ReverseMap();
            CreateMap<Entities.CourseUser, QueryCourseUserDto>().ReverseMap();
            CreateMap<Entities.CourseUser, UpdateCourseUserDto>().ReverseMap();
            CreateMap<Entities.RoleInCourse, RoleInCourseDto>().ReverseMap();
            CreateMap<Entities.TimePlace, TimePlaceDto>().ReverseMap();
            CreateMap<Entities.TimePlace, InsertTimePlaceDto>().ReverseMap();
        }
    }
}

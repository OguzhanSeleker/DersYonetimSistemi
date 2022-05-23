using AutoMapper;
using Services.Homework.Application.Dtos;
using Services.Homework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Homework.Application.Mapping
{
    public class HomeworkMapping : Profile
    {
        public HomeworkMapping()
        {
            CreateMap<HomeworkInformation,GetHomeworkInformation>().ReverseMap();
            CreateMap<HomeworkInformation,AddHomeworkInformation>().ReverseMap();
            CreateMap<HomeworkMetadata,GetHomeworkMetadata>().ReverseMap();
            CreateMap<HomeworkMetadata, AddHomeworkMetadata>().ReverseMap();
            CreateMap<StudentHomeworkMetadata,GetStudentHomeworkMetadata>().ReverseMap();   
            CreateMap<StudentHomeworkMetadata, AddStudentHomeworkMetadata>().ReverseMap();
        }
    }
}

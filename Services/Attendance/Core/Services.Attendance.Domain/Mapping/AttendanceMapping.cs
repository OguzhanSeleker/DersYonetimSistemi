using AutoMapper;
using Services.Attendance.Domain.Dtos;
using Services.Attendance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Attendance.Domain.Mapping
{
    public class AttendanceMapping : Profile
    {
        public AttendanceMapping()
        {
            CreateMap<CourseAttendance, AddCourseAttendanceDto>().ReverseMap();
            CreateMap<CourseAttendance, GetCourseAttendanceDto>().ReverseMap();
            CreateMap<CourseProgramInfo, AddCourseProgramInfoDto>().ReverseMap();
            CreateMap<CourseProgramInfo, GetCourseProgramInfoDto>().ReverseMap();
            CreateMap<StudentAttendance, AddStudentAttendanceDto>().ReverseMap();
            CreateMap<StudentAttendance, GetStudentAttendanceDto>().ReverseMap();
        }
    }
}

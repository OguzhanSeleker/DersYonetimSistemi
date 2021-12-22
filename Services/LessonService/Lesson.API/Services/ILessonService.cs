using Lesson.API.Dtos;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson.API.Services
{
    public interface ILessonService
    {
        Task<OperationResult<NoContent>> AddLesson(CreateLessonDto createLessonDto);
        Task<OperationResult<NoContent>> AddStudents(StudentDto studentDto);
    }
}

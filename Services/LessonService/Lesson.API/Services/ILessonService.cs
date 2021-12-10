using Lesson.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson.API.Services
{
    public interface ILessonService
    {
        Task<bool> AddLesson(CreateLessonDto createLessonDto);
    }
}

using Lesson.API.Dtos;
using Lesson.Domain.Interfaces;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson.API.Services
{
    public interface ILessonCodeService
    {
        Task<OperationResult<bool>> AddLessonCode(AddLessonCodeDto AddlessonCodeDto);
        Task<OperationResult<>>
        
    }
}

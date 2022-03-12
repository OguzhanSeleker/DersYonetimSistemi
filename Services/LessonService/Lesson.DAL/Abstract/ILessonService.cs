using Lesson.DAL.Concrete.Dtos;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.DAL.Abstract
{
    public interface ILessonService 
    {
        Task<OperationResult<LessonDto>> CreateLessonAsync(AddLessonDto addLessonDto);
        Task<OperationResult<LessonDto>> GetByIdAsync(GetLessonDto getLessonDto);
        Task<OperationResult<List<LessonDto>>> GetAllAsync();
        Task<OperationResult<NoContent>> UpdateLessonAsync(UpdateLessonDto updateLessonDto);
        Task<OperationResult<NoContent>> AddStudentToLessonAsync(AddStudentsToLessonDto addStudentsToLessonDto);
        Task<OperationResult<NoContent>> AddAssistantToLessonAsync(AddAssistantToLessonDto addAssistantToLessonDto);
        Task<OperationResult<NoContent>> DeleteLesson(DeleteLessonDto deleteLessonDto);
        Task<OperationResult<NoContent>> RemoveStudentsFromLessonAsync(RemoveStudentsFromLessonDto removeStudentsFromLessonDto);
        Task<OperationResult<NoContent>> RemoveAssistantsFromLessonAsync(RemoveAssistantsFromLessonDto removeAssistantsFromLessonDto);
        Task<OperationResult<NoContent>> AddLecturerToLessonAsync(AddLecturerToLessonDto addLecturerToLessonDto);
        Task<OperationResult<NoContent>> RemoveLecturerFromLessonAsync(RemoveLecturerFromLessonDto removeLecturerFromLessonDto);
    }
}

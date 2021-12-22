using Lesson.API.Dtos;
using Lesson.API.Mapping;
using Lesson.Domain.Interfaces;
using Lesson.Infrastructure.Repositories;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson.API.Services
{
    public class LessonService : ILessonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILessonRepository _lessonRepository;
        private readonly ILessonCodeRepository _lessonCodeRepository;

        public LessonService(IUnitOfWork unitOfWork, ILessonRepository lessonRepository, ILessonCodeRepository lessonCodeRepository)
        {
            _unitOfWork = unitOfWork;
            _lessonRepository = lessonRepository;
            _lessonCodeRepository = lessonCodeRepository;
        }

        public async Task<OperationResult<NoContent>> AddLesson(CreateLessonDto createLessonDto)
        {
            try
            {
                var lesson = ObjectMapper.Mapper.Map<Domain.Aggregates.Lesson>(createLessonDto);
                _lessonRepository.Add(lesson);
                await _unitOfWork.CommitAsync();
                return OperationResult<NoContent>.CreatedSuccessResult();
            }
            catch (Exception ex)
            {
                return OperationResult<NoContent>.CreateFailure(ex);
            }
            
        }

        public Task<OperationResult<NoContent>> AddStudents(StudentDto studentDto)
        {
            throw new NotImplementedException();
        }
    }
}

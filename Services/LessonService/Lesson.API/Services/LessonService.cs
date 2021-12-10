using Lesson.API.Dtos;
using Lesson.Domain.Interfaces;
using Lesson.Infrastructure.Repositories;
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

        public async Task<bool> AddLesson(CreateLessonDto createLessonDto)
        {
            throw new NotImplementedException();
        }
    }
}

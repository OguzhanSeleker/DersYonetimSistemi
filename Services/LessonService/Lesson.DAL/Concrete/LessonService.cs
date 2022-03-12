using AutoMapper;
using Lesson.DAL.Abstract;
using Lesson.DAL.Concrete.Dtos;
using MongoDB.Driver;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.DAL.Concrete
{
    public class LessonService : ILessonService
    {
        private readonly IMongoCollection<Entities.Lesson> _lessonCollection;
        private readonly IMapper _mapper;

        public LessonService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var db = client.GetDatabase(databaseSettings.DatabaseName);
            _lessonCollection = db.GetCollection<Entities.Lesson>(databaseSettings.LessonCollectionName);
            _mapper = mapper;
        }

        public async Task<OperationResult<NoContent>> AddAssistantToLessonAsync(AddAssistantToLessonDto addAssistantToLessonDto)
        {
            var lesson = await _lessonCollection.Find(i => !i.IsDeleted && i.IsActive && i.LessonId == addAssistantToLessonDto.LessonId).FirstOrDefaultAsync();
            if (lesson != null)
            {
                var filter = Builders<Entities.Lesson>.Filter.Eq(q => q.LessonId, addAssistantToLessonDto.LessonId);
                var update = Builders<Entities.Lesson>.Update.AddToSetEach(i => i.Assistants, addAssistantToLessonDto.Assistants);
                var result = await _lessonCollection.UpdateOneAsync(filter, update);
                if (result.IsModifiedCountAvailable)
                    return OperationResult<NoContent>.CreatedSuccessResult();
                else
                    return OperationResult<NoContent>.CreateFailure("Asistanlar eklenemedi", StatusCode.Error);
            }
            return OperationResult<NoContent>.CreateFailure("Ders Bulunamadı.", StatusCode.NotFound);
        }

        public async Task<OperationResult<NoContent>> AddLecturerToLessonAsync(AddLecturerToLessonDto addLecturerToLessonDto)
        {
            var lesson = await _lessonCollection.Find(i => !i.IsDeleted && i.IsActive && i.LessonId == addLecturerToLessonDto.LessonId).FirstOrDefaultAsync();
            if (lesson != null)
            {
                var filter = Builders<Entities.Lesson>.Filter.Eq(q => q.LessonId, lesson.LessonId);
                var update = Builders<Entities.Lesson>.Update.AddToSetEach(i => i.Lecturers, new List<LecturerDto>() { addLecturerToLessonDto.Lecturer });
                var result = await _lessonCollection.UpdateOneAsync(filter, update);
                if (result.IsModifiedCountAvailable)
                    return OperationResult<NoContent>.CreatedSuccessResult();
                else
                    return OperationResult<NoContent>.CreateFailure("Öğretim Görevlisi Eklenemdi.", StatusCode.Error);
            }
            return OperationResult<NoContent>.CreateFailure("Ders Bulunamadı.", StatusCode.NotFound);
        }

        public async Task<OperationResult<NoContent>> AddStudentToLessonAsync(AddStudentsToLessonDto addStudentsToLessonDto)
        {
            var lesson = await _lessonCollection.Find(i => !i.IsDeleted && i.IsActive && i.LessonId == addStudentsToLessonDto.LessonId).FirstOrDefaultAsync();
            if (lesson != null)
            {
                var filter = Builders<Entities.Lesson>.Filter.Eq(q => q.LessonId, addStudentsToLessonDto.LessonId);
                var update = Builders<Entities.Lesson>.Update.AddToSetEach(i => i.Students, addStudentsToLessonDto.Students);
                var result = await _lessonCollection.UpdateOneAsync(filter, update);
                if (result.IsModifiedCountAvailable)
                    return OperationResult<NoContent>.CreatedSuccessResult();
                else
                    return OperationResult<NoContent>.CreateFailure("Öğrenciler eklenemedi", StatusCode.Error);
            }
            return OperationResult<NoContent>.CreateFailure("Ders Bulunamadı.", StatusCode.NotFound);
        }

        public async Task<OperationResult<LessonDto>> CreateLessonAsync(AddLessonDto addLessonDto)
        {
            var lesson = _mapper.Map<Entities.Lesson>(addLessonDto);
            lesson.IsActive = true;
            lesson.IsDeleted = false;
            lesson.CreatedDate = DateTime.Now;
            try
            {
                await _lessonCollection.InsertOneAsync(lesson);
                return OperationResult<LessonDto>.OkSuccessResult(_mapper.Map<LessonDto>(lesson));
            }
            catch (Exception e)
            {
                return OperationResult<LessonDto>.CreateFailure(e.Message, StatusCode.Error);
            }
        }

        public async Task<OperationResult<NoContent>> DeleteLesson(DeleteLessonDto deleteLessonDto)
        {
            var filter = Builders<Entities.Lesson>.Filter.Eq(i => i.LessonId, deleteLessonDto.LessonId);
            var update = Builders<Entities.Lesson>.Update.Set(i => i.IsDeleted, true).Set(i => i.IsActive, false);
            try
            {
                var result = await _lessonCollection.UpdateOneAsync(filter, update);
                return OperationResult<NoContent>.CreatedSuccessResult();

            }
            catch (Exception e)
            {
                return OperationResult<NoContent>.CreateFailure(e.Message, StatusCode.Error);
            }

        }

        public async Task<OperationResult<List<LessonDto>>> GetAllAsync()
        {
            var lessons = await _lessonCollection.Find(i => i.IsActive && !i.IsDeleted).ToListAsync();
            if (lessons.Any())
                return OperationResult<List<LessonDto>>.OkSuccessResult(_mapper.Map<List<LessonDto>>(lessons));
            else
                return OperationResult<List<LessonDto>>.CreateFailure("Ders bulunamadı", StatusCode.NotFound);
        }

        public async Task<OperationResult<LessonDto>> GetByIdAsync(GetLessonDto getLessonDto)
        {
            var lesson = await _lessonCollection.Find<Entities.Lesson>(i => i.LessonId == getLessonDto.LessonId && !i.IsDeleted && i.IsActive).FirstOrDefaultAsync();
            if (lesson != null)
                return OperationResult<LessonDto>.OkSuccessResult(_mapper.Map<LessonDto>(lesson));
            else
                return OperationResult<LessonDto>.CreateFailure("Ders bulunamadı", StatusCode.NotFound);
        }

        public async Task<OperationResult<NoContent>> RemoveAssistantsFromLessonAsync(RemoveAssistantsFromLessonDto removeAssistantsFromLessonDto)
        {
            var lesson = await _lessonCollection.Find(i => i.LessonId == removeAssistantsFromLessonDto.LessonId && i.IsActive && !i.IsDeleted).FirstOrDefaultAsync();
            if (lesson != null)
            {
                try
                {
                    var filter = Builders<Entities.Lesson>.Filter.Eq(i => i.LessonId, lesson.LessonId);
                    foreach (var assistantId in removeAssistantsFromLessonDto.AssistantIdList)
                    {
                        var remove = Builders<Entities.Lesson>.Update.PullFilter(i => i.Assistants, Builders<AssistantDto>.Filter.Where(x => x.AssistantId == assistantId));
                        var result = await _lessonCollection.UpdateOneAsync(filter, remove);
                    }
                    return OperationResult<NoContent>.CreatedSuccessResult();
                }
                catch (Exception e)
                {
                    return OperationResult<NoContent>.CreateFailure(e.Message, StatusCode.Error);
                }

            }
            return OperationResult<NoContent>.CreateFailure("Ders bulunamadı", StatusCode.NotFound);
        }

        public async Task<OperationResult<NoContent>> RemoveLecturerFromLessonAsync(RemoveLecturerFromLessonDto removeLecturerFromLessonDto)
        {
            var lesson = await _lessonCollection.Find(i => i.LessonId == removeLecturerFromLessonDto.LessonId && i.IsActive && !i.IsDeleted).FirstOrDefaultAsync();
            if (lesson != null)
            {

                try
                {
                    var filter = Builders<Entities.Lesson>.Filter.Eq(i => i.LessonId, lesson.LessonId);
                    var remove = Builders<Entities.Lesson>.Update.PullFilter(i => i.Lecturers, Builders<LecturerDto>.Filter.Where(x => x.LecturerId == removeLecturerFromLessonDto.Lecturer.LecturerId));
                    var result = await _lessonCollection.UpdateOneAsync(filter, remove);
                    return OperationResult<NoContent>.CreatedSuccessResult();
                }
                catch (Exception e)
                {
                    return OperationResult<NoContent>.CreateFailure(e.Message, StatusCode.Error);
                }

            }
            return OperationResult<NoContent>.CreateFailure("Ders bulunamadı", StatusCode.NotFound);
        }

        public async Task<OperationResult<NoContent>> RemoveStudentsFromLessonAsync(RemoveStudentsFromLessonDto removeStudentsFromLessonDto)
        {
            var lesson = await _lessonCollection.Find(i => i.LessonId == removeStudentsFromLessonDto.LessonId && i.IsActive && !i.IsDeleted).FirstOrDefaultAsync();
            if (lesson != null)
            {

                try
                {
                    var filter = Builders<Entities.Lesson>.Filter.Eq(i => i.LessonId, lesson.LessonId);
                    foreach (var studentId in removeStudentsFromLessonDto.StudentIdList)
                    {
                        var remove = Builders<Entities.Lesson>.Update.PullFilter(i => i.Students, Builders<StudentDto>.Filter.Where(x => x.StudentId == studentId));
                        var result = await _lessonCollection.UpdateOneAsync(filter, remove);
                    }
                    return OperationResult<NoContent>.NoContentSuccessResult();
                }
                catch (Exception e)
                {
                    return OperationResult<NoContent>.CreateFailure(e.Message, StatusCode.Error);
                }
            }
            return OperationResult<NoContent>.CreateFailure("Ders bulunamadı", StatusCode.NotFound);
        }

        public async Task<OperationResult<NoContent>> UpdateLessonAsync(UpdateLessonDto updateLessonDto)
        {
            var updateLesson = _mapper.Map<Entities.Lesson>(updateLessonDto);
            var result = await _lessonCollection.FindOneAndReplaceAsync(i => i.LessonId == updateLessonDto.LessonId, updateLesson);
            if (result != null)
                return OperationResult<NoContent>.CreatedSuccessResult();
            else
                return OperationResult<NoContent>.CreateFailure("Ders bulunamadı", StatusCode.NotFound);
        }
    }
}

using Lesson.DAL.Concrete.Dtos;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.DAL.Concrete.Entities
{
    public class Lesson
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string LessonId { get; set; }
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public string LessonCRN { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime StartDate { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime EndDate { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime LastAccessDate { get; set; }
        public List<TimeDayDto> TimesDays { get; set; }
        public List<LecturerDto> Lecturers { get; set; }
        public List<AssistantDto> Assistants { get; set; }
        public List<StudentDto> Students { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime CreatedDate { get; set; }
        public string CreatorUser { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }

   
    
}

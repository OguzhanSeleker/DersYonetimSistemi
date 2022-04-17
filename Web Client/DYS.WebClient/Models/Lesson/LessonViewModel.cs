using System;

namespace DYS.WebClient.Models.Lesson
{
    public class LessonViewModel
    {
        public string NameTR { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public Guid CoordinatorId { get; set; }
        public string CoordinatorFullName { get; set; }
        public string Language { get; set; }
        public int TermNumber { get; set; }
        public double Credit { get; set; }
        public string Goals { get; set; }
        public string Descriptions { get; set; }
        public string OtherInformations { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}

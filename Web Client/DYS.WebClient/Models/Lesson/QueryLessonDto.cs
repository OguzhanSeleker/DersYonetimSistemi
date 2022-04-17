using Newtonsoft.Json;
using System;

namespace DYS.WebClient.Models.Lesson
{

    public class QueryLessonDto : GetDto
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
    }
}

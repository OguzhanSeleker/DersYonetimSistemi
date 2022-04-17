using Services.Lesson.Domain.Entities.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Lesson.Domain.Entities
{
    public class Lesson : BaseEntity
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
        public virtual ICollection<Course> Courses { get; set; }

    }

}

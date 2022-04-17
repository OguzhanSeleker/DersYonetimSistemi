using Services.Survey.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Survey.Domain.Entities
{
    public class AnswerType : BaseEntity
    {
        public string TypeName { get; set; }
        public string TypeKey { get; set; }
    }
}

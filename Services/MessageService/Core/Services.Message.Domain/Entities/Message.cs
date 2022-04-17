using Services.Message.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Message.Domain.Entities
{
    public class Message : BaseEntity
    {
        public Guid WriterId { get; set; }
        public Guid LessonId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(Domain.Entities.Message))]
        public Nullable<Guid> UpperMessageId { get; set; }
        public Message UpperMessage { get; set; }

    }
}

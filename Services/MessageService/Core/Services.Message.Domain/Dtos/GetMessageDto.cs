using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Message.Domain.Dtos
{
    public class GetMessageDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Deleted { get; set; }
        public Guid WriterId { get; set; }
        public Guid LessonId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<Guid> UpperMessageId { get; set; }
    }
}

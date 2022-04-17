using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Message.Domain.Dtos
{
    public class AddMessageDto
    {
        [Required]
        public Guid WriterId { get; set; }
        [Required]
        public Guid LessonId { get; set; }
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public Nullable<Guid> UpperMessageId { get; set; }
    }
}

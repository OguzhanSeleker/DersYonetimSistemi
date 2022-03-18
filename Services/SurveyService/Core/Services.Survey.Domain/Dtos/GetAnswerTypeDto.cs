using System;

namespace Services.Survey.Domain.Dtos
{
    public class GetAnswerTypeDto : IDto
    {
        public Guid Id { get; set; }
        public string TypeName { get; set; }
        public string TypeKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}

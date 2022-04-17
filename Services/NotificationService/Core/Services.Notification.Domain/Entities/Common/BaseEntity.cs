using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Notification.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}

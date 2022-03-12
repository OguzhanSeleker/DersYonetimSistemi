﻿using Services.Notification.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Notification.Domain.Entities
{
    public class Notication : BaseEntity
    {
        public Guid WriterId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Priority { get; set; }
        public Guid LessonId { get; set; }
    }
}

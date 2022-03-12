﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Notification.Domain.Dtos
{
    public class AddNotificationDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid WriterId { get; set; }
        [Required]
        public Guid LessonId { get; set; }
        [Required]
        public bool Priority { get; set; }
    }
}

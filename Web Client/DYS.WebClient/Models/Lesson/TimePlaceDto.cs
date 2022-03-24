﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DYS.WebClient.Models.Lesson
{
    public class TimePlaceDto : GetDto
    {
        [Required]
        public DayOfWeek DayOfWeek { get; set; }
        [Required]
        public string StartHour { get; set; }
        [Required]
        public string EndHour { get; set; }
        [Required]
        public string ClassRoom { get; set; }
        [Required]
        public Guid CourseId { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYS.WebClient.Models.CourseFileSystem
{
    public class GetFileSystemDto
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string CourseCRN { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public bool Deleted { get; set; }
    }
}
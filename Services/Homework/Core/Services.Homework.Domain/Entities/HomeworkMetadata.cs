﻿using Services.Homework.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Homework.Domain.Entities
{
    public class HomeworkMetadata : BaseEntity
    {
        public string HomeworkInformationId { get; set; }
        public string FullPath { get; set; }
        public string ShortPath { get; set; }
        public string Extension { get; set; }
        public string DisplayName { get; set; }
        public bool Active { get; set; }
    }
}

﻿using Newtonsoft.Json;
using System;

namespace DYS.WebClient.Models.Lesson
{
    [JsonObject]
    public class QueryLessonDto : GetDto
    {
        public QueryLessonDto()
        {

        }
        [JsonProperty("nameTR")]
        public string NameTR { get; set; }
        [JsonProperty("nameEn")]
        public string NameEn { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("coordinatorId")]
        public Guid CoordinatorId { get; set; }
        [JsonProperty("coordinatorFullName")]
        public string CoordinatorFullName { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("termNumber")]
        public int TermNumber { get; set; }
        [JsonProperty("credit")]
        public double Credit { get; set; }
        [JsonProperty("goals")]
        public string Goals { get; set; }
        [JsonProperty("descriptions")]
        public string Descriptions { get; set; }
        [JsonProperty("otherInformations")]
        public string OtherInformations { get; set; }
    }
}

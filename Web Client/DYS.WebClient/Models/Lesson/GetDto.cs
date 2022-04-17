using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace DYS.WebClient.Models.Lesson
{
    [JsonObject]
    public class GetDto : IDto
    {
        public GetDto()
        {

        }
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("createdBy")]
        public Guid CreatedBy { get; set; }
        [JsonProperty("updatedDate")]
        public DateTime? UpdatedDate { get; set; }
        [JsonProperty("updatedBy")]
        public Guid? UpdatedBy { get; set; }
        [JsonProperty("deletedDate")]
        public DateTime? DeletedDate { get; set; }
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }
}

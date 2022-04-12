using DYS.WebClient.Filters;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace DYS.WebClient.Models
{
    public class FileOperationModel
    {
        [Required]
        public string CourseCRN { get; set; }
        [Required]
        public Guid CourseId { get; set; }
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(20971520)]
        [AllowedExtensions(new string[] { ".pdf", ".docx",".png",".jpeg", ".jpg",".rar" })]
        [Display(Name ="Dosya")]
        public IFormFile File { get; set; }
        public string FileName { get; set; }
    }
}
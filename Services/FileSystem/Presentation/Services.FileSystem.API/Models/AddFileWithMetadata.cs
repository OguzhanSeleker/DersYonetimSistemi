using Microsoft.AspNetCore.Http;
using Services.FileSystem.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.FileSystem.API.Models
{
    public class AddFileWithMetadata
    {
        public AddFileSystemDto AddFileSystemDto { get; set; }
        public IFormFile File{ get; set; }
    }
}

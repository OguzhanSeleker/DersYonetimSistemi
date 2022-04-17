using AutoMapper;
using Services.FileSystem.Domain.Dtos;
using Services.FileSystem.Domain.Entities;

namespace Services.FileSystem.Domain.Mapping
{
    public class FileSystemMapping : Profile
    {
        public FileSystemMapping()
        {
            CreateMap<WebFileSystem, AddFileSystemDto>().ReverseMap();
            CreateMap<WebFileSystem, GetFileSystemDto>().ReverseMap();
        }
    }
}

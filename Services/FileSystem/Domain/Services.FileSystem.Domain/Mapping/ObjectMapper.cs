using AutoMapper;
using System;

namespace Services.FileSystem.Domain.Mapping
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(config =>
            {
                config.AddProfile<FileSystemMapping>();
            });
            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }
}

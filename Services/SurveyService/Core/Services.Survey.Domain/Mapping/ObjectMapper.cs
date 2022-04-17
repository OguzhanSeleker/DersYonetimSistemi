using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Survey.Domain.Mapping
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(config =>
            {
                config.AddProfile<SurveyMapping>();
            });
            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }
}

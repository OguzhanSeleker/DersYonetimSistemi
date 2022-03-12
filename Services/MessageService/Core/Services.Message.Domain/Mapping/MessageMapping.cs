using AutoMapper;
using Services.Message.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Message.Domain.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<Domain.Entities.Message, GetMessageDto>().ReverseMap();
            CreateMap<Domain.Entities.Message, AddMessageDto>().ReverseMap();
        }
    }
}

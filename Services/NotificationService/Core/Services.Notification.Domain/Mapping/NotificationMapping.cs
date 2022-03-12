using AutoMapper;
using Services.Notification.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Notification.Domain.Mapping
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping()
        {
            CreateMap<Entities.Notication, GetNotificationDto>().ReverseMap();
            CreateMap<Entities.Notication, AddNotificationDto>().ReverseMap();
            CreateMap<Entities.Notication, UpdateNotificationDto>().ReverseMap();
        }
    }
}

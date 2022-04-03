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
            CreateMap<Entities.Notification, GetNotificationDto>().ReverseMap();
            CreateMap<Entities.Notification, AddNotificationDto>().ReverseMap();
            CreateMap<Entities.Notification, UpdateNotificationDto>().ReverseMap();
        }
    }
}

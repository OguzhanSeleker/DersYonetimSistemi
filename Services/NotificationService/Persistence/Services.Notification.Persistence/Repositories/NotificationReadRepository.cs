using Services.Notification.Application.Repositories;
using Services.Notification.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Notification.Persistence.Repositories
{
    public class NotificationReadRepository : ReadRepository<Domain.Entities.Notication>, INotificationReadRepository
    {
        public NotificationReadRepository(NotificationServiceDbContext context) : base(context)
        {
        }
    }
}

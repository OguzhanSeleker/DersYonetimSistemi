using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Notification.Application.Repositories
{
    public interface INotificationReadRepository : IReadRepository<Domain.Entities.Notification>
    {
    }
}

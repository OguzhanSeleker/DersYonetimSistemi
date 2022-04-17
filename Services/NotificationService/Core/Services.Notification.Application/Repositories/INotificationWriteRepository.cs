using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Notification.Application.Repositories
{
    public interface INotificationWriteRepository : IWriteRepository<Domain.Entities.Notification>
    {
    }
}

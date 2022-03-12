using Services.Message.Application.Repositories;
using Services.Message.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Message.Persistence.Repositories.Message
{
    public class MessageReadRepository : ReadRepository<Domain.Entities.Message>, IMessageReadRepository
    {
        public MessageReadRepository(MessageServiceDbContext context) : base(context)
        {
        }
    }
}

using Services.Message.Application.Repositories;
using Services.Message.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Message.Persistence.Repositories.Message
{
    public class MessageWriteRepository : WriteRepository<Domain.Entities.Message>, IMessageWriteRepository
    {
        public MessageWriteRepository(MessageServiceDbContext context) : base(context)
        {
        }
    }
}

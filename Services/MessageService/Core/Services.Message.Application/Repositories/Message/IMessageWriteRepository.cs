using Services.Message.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Message.Application.Repositories
{
    public interface IMessageWriteRepository : IWriteRepository<Domain.Entities.Message>
    {
    }
}

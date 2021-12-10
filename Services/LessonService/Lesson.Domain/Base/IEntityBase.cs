using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Base
{
    public interface IEntityBase<TKey>
    {
        TKey ObjectId { get; set; }
    }
}

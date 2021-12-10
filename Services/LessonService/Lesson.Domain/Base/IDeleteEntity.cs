using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Base
{
    public interface IDeleteEntity
    {
        bool IsDeleted { get; set; }
    }
    public interface IDeleteEntity<TKey> : IDeleteEntity, IEntityBase<TKey>
    {

    }

}

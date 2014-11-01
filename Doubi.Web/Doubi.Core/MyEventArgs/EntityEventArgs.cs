using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubi.Core.MyEventArgs
{
    public class EntityEventArgs<T>
    {
        public EntityEventArgs(T s)
        {
            this.Entity = s;
        }
        public T Entity
        { get; private set; }
    }
}

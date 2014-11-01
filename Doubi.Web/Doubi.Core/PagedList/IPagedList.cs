using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubi.Core.PagedList
{
    /// <summary>
    /// Paged list interface
    /// </summary>
    public interface IPagedList<T> : IPageable, IList<T>
    {
        // codehint: sm-delete (members of IPageable now)
    }
}

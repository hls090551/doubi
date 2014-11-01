using System;

namespace Doubi.Core
{
    public interface IOrdered
    {
        // TODO: (MC) Make Nullable!
        int Ordinal { get; set; }
    }
}

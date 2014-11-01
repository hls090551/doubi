using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{

    public partial class ProductType
    {
        public int Id
        {
            get;
            set;
        }
        public short Type
        {
            get;
            set;
        }
        public string Desc
        {
            get;
            set;
        }
    }
}

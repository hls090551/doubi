using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class ProductSupplier
    
	{	
			public int Id
			{
				get;
				set;
			}
			public int Productid
			{
				get;
				set;
			}
			public string Supplier_name
			{
				get;
				set;
			}
			public decimal Supplier_price
			{
				get;
				set;
			}
			public string Map_productcode
			{
				get;
				set;
			}
			public int Supplier_inventory
			{
				get;
				set;
			}
			public string Supplier_code
			{
				get;
				set;
			}
			public short Suppliertype
			{
				get;
				set;
			}
	}
}

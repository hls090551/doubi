using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Doubi.Core.Domain
{	
	
	public partial class SiteNews
    
	{	
			public int Id
			{
				get;
				set;
			}
			public string Title
			{
				get;
				set;
			}
			public string Body
			{
				get;
				set;
			}
			public int Creator
			{
				get;
				set;
			}
			public string Image
			{
				get;
				set;
			}
			public int Position
			{
				get;
				set;
			}
			public bool Isspecial
			{
				get;
				set;
			}
			public DateTime Createtime
			{
				get;
				set;
			}
	}
}

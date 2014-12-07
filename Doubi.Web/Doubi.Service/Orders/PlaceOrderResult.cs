using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubi.Service.Orders
{
   public  class PlaceOrderResult
    {
       public string Retmsg { get; set; }
        public int RetCode { get; set; }
        public bool Success
        {
            get { return (this.RetCode == 0); }
        }

        public void AddError(int code,string error)
        {
            this.Retmsg = error;
            this.RetCode = code;
        }      
    }
}

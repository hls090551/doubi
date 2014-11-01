using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentData;

namespace Doubi.Data.DAL
{
    public partial class ShoppingCartRepository<T>
    {
        public T GetShoppingCart(int userid, int pcid)
        {
            if (userid <= 0 || pcid <= 0)
            {
                throw new ArgumentException(" ShoppingCartRepository.GetShoppingCart args error! ");
            }
            using (var context = Context())
            {
                return context.Sql(" select * from shopping_cart where userid=@0 and pcid=@1 ")
                     .Parameters(userid, pcid)
                     .QuerySingle<T>();
            }
        }
    }
}





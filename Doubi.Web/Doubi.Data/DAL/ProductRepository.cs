using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentData;

namespace Doubi.Data.DAL
{
    public partial class ProductRepository<T>
    {
        public T GetProduct(int pcid)
        {
            if (pcid <= 0)
            {
                throw new ArgumentException("ProductRepository.GetProduct args error");
            }
            var products = this.SelectByField("id", pcid);
            if (products == null && products.Count <= 0)
            {
                return null;
            }
            return products[0];
        }
    }
}





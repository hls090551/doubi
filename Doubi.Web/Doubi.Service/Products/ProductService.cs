using Doubi.Core.Domain;
using Doubi.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubi.Service.Products
{
    public class ProductService
    {
        private readonly ProductRepository<Product> _proRepository;

        public ProductService()
        {
            _proRepository = new ProductRepository<Product>();
        }

        public Product GetProduct(int pcid)
        {
            if (pcid <= 0)
            {
                return null;
            }
            return _proRepository.GetProduct(pcid);
        }
    }
}

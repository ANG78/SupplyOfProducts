using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.Persistance
{
    public class ProductStockRepository : BaseRepository, IProductStockRepository
    {
        public ProductStockRepository(MemoryContext context) : base(context)
        {
        }

        public void Add(IProductStock worker)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(IProductStock worker)
        {
            throw new System.NotImplementedException();
        }

        public IProductStock Get(string partNumber)
        {
            return Context.ProductsStock
                            .Where(x=>x.Code == partNumber)
                            .FirstOrDefault();
        }

        public IEnumerable<IProductStock> Get()
        {
            throw new System.NotImplementedException();
        }

        public IProductStock GetAvailable(string codProduct)
        {
            return Context.ProductsStock
                        .Where(x => x.Product.Code == codProduct && x.BookingId == null )
                        .FirstOrDefault();
        }

        public void Save(IProductStock product)
        {
            if (product.Id == 0)
            {
                Context.ProductsStock.Add(product);
            }
        }
    }
}

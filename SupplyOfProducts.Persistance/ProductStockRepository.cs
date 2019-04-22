using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Linq;

namespace SupplyOfProducts.Persistance
{
    public class ProductStockRepository : BaseRepository, IProductStockRepository
    {
        public ProductStockRepository(MemoryContext context) : base(context)
        {
        }

        public IProductStock Get(string partNumber)
        {
            return Context.ProductsStock.FirstOrDefault(x=>x.PartNumber == partNumber);
        }

        public IProductStock GetAvailable(string codProduct)
        {
            return Context.ProductsStock.FirstOrDefault(x => x.Product.Code == codProduct && x.IdBooking == 0);
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

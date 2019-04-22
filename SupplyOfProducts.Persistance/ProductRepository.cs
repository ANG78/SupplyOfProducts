using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Linq;

namespace SupplyOfProducts.Persistance
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(MemoryContext context) : base (context)
        { }

        public IProduct Get(string code)
        {
            return Context.Products.FirstOrDefault(x => x.Code == code);
        }
    }

    
}

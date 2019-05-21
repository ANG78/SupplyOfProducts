using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.Persistance
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(MemoryContext context) : base (context)
        { }

        public void Add(IProduct worker)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(IProduct worker)
        {
            throw new System.NotImplementedException();
        }

        public IProduct Get(string code)
        {
            return Context.Products.FirstOrDefault(x => x.Code == code);
        }

        public IEnumerable<IProduct> Get()
        {
            throw new System.NotImplementedException();
        }
    }

    
}

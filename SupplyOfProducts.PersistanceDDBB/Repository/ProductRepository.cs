using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Linq;

namespace SupplyOfProducts.PersistanceDDBB.Repository
{

    public class ProductRepository : GenericRepository<Product>, IGenericRepository<Product>, IProductRepository
    {

        public ProductRepository(IGenericContext dbContext) : base(dbContext)
        {

        }

        public IProduct Get(string code)
        {
            var result = _Current.Where(p => p.Code == code).FirstOrDefault();

            if (result == null)
            {
                return null;
            }

            var products = _Current.Where(x => x.ParentProductId == result.Id).ToList();
            if (products.Count == 0)
            {
                return result;
            }


            var package = new PackageProduct(result);
            products.ForEach(x => package.Add(x));

            return package;

        }
    }



}

using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.BusinessLogic.Services
{
    public class ProductService : GenericService<IProduct>, IProductService
    {
   

        public ProductService(IProductRepository pproductRepository) : base(pproductRepository)
        {
           
        }

      
    }


}

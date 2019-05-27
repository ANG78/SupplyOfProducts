using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.BusinessLogic.Services
{
    public class ProductService : GenericServiceCode<IProduct>, IProductService
    {
   

        public ProductService(IProductRepository pproductRepository) : base(pproductRepository)
        {
           
        }

      
    }

    

}

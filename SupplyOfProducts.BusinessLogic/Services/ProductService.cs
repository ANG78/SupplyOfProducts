using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        readonly IProductRepository productRepository;

        public ProductService(IProductRepository pproductRepository)
        {
            productRepository = pproductRepository;
        }

        public IProduct Get(string code)
        {
            return productRepository.Get(code);
        }
    }


}

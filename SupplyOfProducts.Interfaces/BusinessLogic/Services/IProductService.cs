using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{
    public interface IProductService
    {
        IProduct Get(string code);
    }

}

using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Interfaces.Repository
{
    public interface IProductRepository
    {
        IProduct Get(string code);
    }
}

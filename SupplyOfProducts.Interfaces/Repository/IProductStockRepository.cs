using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Interfaces.Repository
{
    public interface IProductStockRepository
    {
         IProductStock Get(string pairNumber);
         IProductStock GetAvailable(string codProduct);
         void Save(IProductStock product);
    }

    
}

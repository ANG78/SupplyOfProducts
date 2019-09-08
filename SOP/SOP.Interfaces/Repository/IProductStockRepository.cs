using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Interfaces.Repository
{
    public interface IProductStockRepository : IGenericRepository<IProductStock>
    {
         IProductStock GetAvailable(string codProduct);
    }

    
}

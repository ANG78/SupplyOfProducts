using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{
    
    public interface IProductStockService : IGenericService<IProductStock>
    {

        IResultObjects<IProductStock> GetAvailable(IProduct product);
        IResultBooking BookingRequest(IEnumerable<IProductStock> product, int idBooking);
    }
}

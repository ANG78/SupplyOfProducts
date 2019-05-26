using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{
    
    public interface IProductStockService : IGenericService<IProductStock>
    {

        IProductStock GetAvailable(IProduct product);

        IResultBooking BookingRequest(IProductStock product, int idBooking);
    }
}

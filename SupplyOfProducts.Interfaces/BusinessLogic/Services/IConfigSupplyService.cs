using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{
    public interface IConfigSupplyService : IGenericReadService<IConfigSupply>
    {
        IEnumerable<IConfigSupply> GetAll(string workerCode);
    }
}

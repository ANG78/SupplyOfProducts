using SupplyOfProducts.Interfaces.BusinessLogic;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.Repository
{
    public interface IConfigSupplyRepository 
    {
        IEnumerable<IConfigSupply> Get(string WorkerCode);
        IEnumerable<IConfigSupply> Get();
    }

    
}

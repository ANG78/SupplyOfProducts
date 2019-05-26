using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{
    public interface IConfigSupplyService //: IGenericReadService<IConfigSupply>
    {
        IEnumerable<IConfigSupply> Get(string workerCode);
        IEnumerable<IConfigSupply> GetAll();
    }

    

}

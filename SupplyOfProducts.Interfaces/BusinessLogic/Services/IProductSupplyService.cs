using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{
    public interface IProductSupplyService : IGenericReadService<IProductSupply>
    {
        void Save(IProductSupply prodSupply);
        void Remove(IProductSupply prodSupply);
        IEnumerable<IProductSupply> GetAll(string workerCode);
        IList<IProductSupplied> GetProductSuppliedToWorker(string sProduct, string sCodeWorker, string sCodWorkPlace, DateTime date);

    }
}



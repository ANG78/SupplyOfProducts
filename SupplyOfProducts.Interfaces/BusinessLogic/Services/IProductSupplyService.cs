using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{
    public interface IProductSupplyService : IGenericNotSingleCodeService<IProductSupply>
    {
        void Remove(IProductSupply prodSupply);
        IEnumerable<IProductSupply> GetAll(int WorkerInWorkPlaceId, int ProductId, DateTime date);
        IEnumerable<IProductSupplied> GetProductSuppliedToWorker(string sProduct, string sCodeWorker, string sCodWorkPlace, DateTime date);

    }
}



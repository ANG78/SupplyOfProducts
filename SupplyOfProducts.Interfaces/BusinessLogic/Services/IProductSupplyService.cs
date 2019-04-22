using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{
    public interface IProductSupplyService
    {
        void Save(IProductSupply prodSupply);
        void Remove(IProductSupply prodSupply);
        IProductSupply Get(IProductSupply prodSupply);
        IList<IProductSupply> GetProductSuppliedToWorker(string sCodeWorker);
        IList<IProductSupplied> GetProductSuppliedToWorker(string sProduct, string sCodeWorker, string sCodWorkPlace, DateTime date);
    }


}



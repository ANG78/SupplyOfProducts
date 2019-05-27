using SupplyOfProducts.Interfaces.BusinessLogic;
using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.Repository
{
    public interface IProductSupplyRepository : IGenericRepository<IProductSupply>
    {

        void Remove(IProductSupply obj);

        IProductSupply Get(int idWorkerInWorkPlace, int idProduct, DateTime PeriodStartDate);
        IProductSupply Get(int id);

        IList<IProductSupply> GetProductSuppliedToWorker(string sCodeWorker);
        IList<IProductSupplied> GetProductSuppliedToWorkerOnThisPeriod(string sProduct, string sCodeWorker, string sCodWorkPlace, DateTime date);
    }


}

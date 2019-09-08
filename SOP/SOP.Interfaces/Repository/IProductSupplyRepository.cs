using SupplyOfProducts.Interfaces.BusinessLogic;
using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.Repository
{
    public interface IProductSupplyRepository : IGenericNotSingleCodeRepository<IProductSupply>
    {

        void Remove(IProductSupply obj);
        IProductSupply Get(int id);

        IEnumerable<IProductSupply> GetAll(string WorkerCode);
        IEnumerable<IProductSupply> GetAll(int idWorkerInWorkPlace, int idProduct, DateTime PeriodStartDate);
        IEnumerable<IProductSupplied> GetProductSuppliedToWorkerOnThisPeriod(string sProduct, string sCodeWorker, string sCodWorkPlace, DateTime date);
        
    }


}

using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.Repository
{
    public interface IProductSupplyRepository
    {

        void Save(IProductSupply obj);
        void Remove(IProductSupply obj);

        IProductSupply Get(int idWorkerInWorkPlace, int idProduct, DateTime PeriodStartDate);
        IProductSupply Get(int id);

        IProductSupplied GetByProductSupply(int idProductSupply);
        IList<IProductSupply> GetProductSuppliedToWorker(string sCodeWorker);
        IList<IProductSupplied> GetProductSuppliedToWorker(string sProduct, string sCodeWorker, string sCodWorkPlace, DateTime date);
    }


}

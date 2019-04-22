using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.Repository
{
    public interface IWorkerRepository
    {
        IWorker Get(string code);
        IList<IWorkerInWorkPlace> GetWorkPlace(string code, DateTime? date);
    }
}

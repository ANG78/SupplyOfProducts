using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{
    public interface IWorkerService
    {
        IResultObject<IWorker> Get(string code);
        IList<IWorkerInWorkPlace> GetWorkPlaceWhereWorkedTheWorker(string code, DateTime? date );
    }
    
}

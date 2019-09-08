using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{
    public interface IWorkerInWorkPlaceService
    {
        IList<IWorkerInWorkPlace> GetWorkPlaceWhereWorkedTheWorker(string code, DateTime? date);
    }
}

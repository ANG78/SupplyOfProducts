using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{
    public interface IWorkerInWorkPlaceService :  IGenericNotSingleCodeReadService<IWorkerInWorkPlace>
    {
        IList<IWorkerInWorkPlace> GetWorkPlaceWhereWorkedTheWorker(string code, DateTime? date);
    }
}

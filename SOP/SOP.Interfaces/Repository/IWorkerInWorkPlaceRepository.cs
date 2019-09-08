using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.Repository
{
    public interface IWorkerInWorkPlaceRepository
    {
        IList<IWorkerInWorkPlace> GetWorkPlace(string code, DateTime? date);
    }
}

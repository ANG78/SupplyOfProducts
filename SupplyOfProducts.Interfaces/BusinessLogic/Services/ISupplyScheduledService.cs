using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{
    public interface ISupplyScheduledService
    {
        ISupplyScheduled Get(string sProductCode, string sWorkerCode, string sWorkPlaceCode, DateTime date);
        IList<ISupplyScheduled> Get(string sWorkerCode);
        void Save(ISupplyScheduled result);
    }
}

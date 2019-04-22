using SupplyOfProducts.Interfaces.BusinessLogic;
using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.Repository
{
    public interface ISupplyScheduledRepository
    {
        ISupplyScheduled Get(string sProductCode, string sWorkerCode, string sWorkPlaceCode, DateTime date);
        IList<ISupplyScheduled> Get(string sWorkerCode);
        void Save(ISupplyScheduled objSch);
    }
}

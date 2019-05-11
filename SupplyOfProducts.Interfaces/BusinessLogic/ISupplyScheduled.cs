using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface ISupplyScheduled : IContainWorkerInWorkPlaceProperty,
                                        IContainProductProperty
    {
        int Id { get; set; }
        int Amount { get; set; }
        DateTime PeriodDate { get; set; }

        IList<IConfigSupply> ConfiguratedBy { get; set; }
    }
}

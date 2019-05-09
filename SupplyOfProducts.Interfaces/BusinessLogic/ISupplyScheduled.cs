using System;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface ISupplyScheduled:  IContainWorkerInWorkPlaceProperty, 
                                        IContainProductProperty
    {
        int Id { get; set; }
        int Amount { get; set; }
        DateTime PeriodDate { get; set; }
    }
}

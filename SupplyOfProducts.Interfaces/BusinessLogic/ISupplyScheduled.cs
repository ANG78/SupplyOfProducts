using System;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface ISupplyScheduled:  IRequestMustBeCompleted, 
                                        IContainWorkerInWorkPlaceProperty, 
                                        IContainProductProperty
    {
        int Id { get; set; }
        uint Amount { get; set; }
        DateTime PeriodDate { get; set; }
    }
}

using System;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface IConfigSupply : IRequestMustBeCompleted,
                                    IContainDatePeriodProperty,
                                    IContainWorkerInWorkPlaceProperty,
                                    IContainProductProperty

    {
        int Id { get; set; }
        ISupplyScheduled Result { get; set; }
        uint Amount { get; set; }

    }
}

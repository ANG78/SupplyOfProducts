using System;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{

    public interface IConfigSupply :
                     IContainDatePeriodProperty,
                     IContainWorkerInWorkPlaceProperty,
                     IContainProductProperty
    {
        ISupplyScheduled SupplyScheduled { get; set; } 
        int SupplyScheduledId { get; set; }

        int Id { get; set; }
        int Amount { get; set; }
                
    }
}

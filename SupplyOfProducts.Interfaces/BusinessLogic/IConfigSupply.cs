using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{

    public interface IConfigSupply :
                     IContainDatePeriodProperty,
                     IContainWorkerInWorkPlaceProperty,
                     IContainProductProperty,
                     IId
    {
        ISupplyScheduled SupplyScheduled { get; set; } 
        int SupplyScheduledId { get; set; }

        int Amount { get; set; }
                
    }
}

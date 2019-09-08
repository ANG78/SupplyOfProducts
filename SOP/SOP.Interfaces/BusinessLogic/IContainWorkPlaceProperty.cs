using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface IContainWorkPlaceProperty
    {
        int WorkPlaceId { get; set; }
        IWorkPlace WorkPlace { get; set; }
    }
}

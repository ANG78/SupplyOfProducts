using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface IContainWorkPlaceProperty
    {
        int IdWorkPlace { get; set; }
        IWorkPlace WorkPlace { get; set; }
    }
}

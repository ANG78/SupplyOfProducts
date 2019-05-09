using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface IContainProductProperty
    {
        int ProductId { get; set; }
        IProduct Product { get; set; }
    }
}

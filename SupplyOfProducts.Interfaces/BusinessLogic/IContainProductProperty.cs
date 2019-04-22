using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface IContainProductProperty
    {
        int IdProduct { get; set; }
        IProduct Product { get; set; }
    }
}

using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface IProductSupplied
    {
        int Id { get; set; }
        int IdProductSupply { get; set; }
        int IdProductStock { get; set; }
        IProductSupply ProductSupply { get; set; }
        IProductStock ProductStock { get; set; }
        int IdParentProductSupplied { get; set; }
        IProductSupplied ParentProductSupplied { get; set; }
    }
}

using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface IProductSupplied
    {
        int Id { get; set; }
        int ProductSupplyId { get; set; }
        int ProductStockId { get; set; }
        IProductSupply ProductSupply { get; set; }
        IProductStock ProductStock { get; set; } 
    }
}

using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{
    public interface IProductStock 
    {
        IProduct Product { get; set; }
        string PartNumber { get; set; }
        int IdBooking { get; set; }
        int Id { get; set; }
        bool IsAvailable { get; }
    }

    public interface IPackageStock : IProductStock
    {
        IList<IProductStock> Parts { get; set; }
    }
}

using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System.Collections.Generic;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Store
{
    public  abstract partial class ProductStockAbstract
    {
        public int Id { get; set; }
     
        public IProduct Product { get; set; }
        public int ProductId { get; set; }
        public string PartNumber { get; set; }
        public int? BookingId { get; set; }
        public bool IsAvailable { get { return BookingId == 0; } }
    }

    public partial class ProductStock : ProductStockAbstract, IProductStock
    {
    }

    public partial class PackageStock : ProductStockAbstract, IPackageStock
    {
       public IList<IProductStock> Parts { get; set; } = new List<IProductStock>();
    }
}

using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System.Collections.Generic;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Provision
{
    public abstract class ProductStockAbstract 
    {
        public int Id { get; set; }
        public IProduct Product { get; set; }
        public string PartNumber { get; set; }
        public int IdBooking { get; set; }
        public bool IsAvailable { get { return IdBooking == 0; } }
    }

    public class ProductStock : ProductStockAbstract, IProductStock
    {
    }

    public class PackageStock : ProductStockAbstract, IPackageStock
    {
       public IList<IProductStock> Parts { get; set; } = new List<IProductStock>();
    }
}

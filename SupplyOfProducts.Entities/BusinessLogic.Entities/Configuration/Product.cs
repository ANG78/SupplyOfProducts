using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System.Collections.Generic;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{
    public abstract class AbstractProduct 
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
    }

    public class Product : AbstractProduct , IProduct
    {
    }

    public class KitProduct : AbstractProduct , IPackage
    {
        public IList<IProduct> Parts { get; set; } 
    }
    
}

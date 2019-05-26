using System.Collections.Generic;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{
    public partial class Product
    {

       
        public string Class { get; set; }

        public virtual IList<ProductParts> ParentPartOfProducts { get; set; }
        public virtual IList<ProductParts> PartOfProducts { get; set; }
    }


    public partial class ProductParts
    {
        public virtual Product Product { get; set; }
        public virtual Product ParentProduct { get; set; }

        public int ProductId { get; set; }
        public int ParentProductId { get; set; }
    }
}

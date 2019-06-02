using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{
    public partial class ProductPart
    {
        public virtual IProduct Product { get; set; }
        public virtual IProduct ParentProduct { get; set; }

        public int ProductId { get; set; }
        public int ParentProductId { get; set; }
    }
}

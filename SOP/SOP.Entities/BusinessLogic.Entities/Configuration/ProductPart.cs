using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{
    public partial class ProductPart
    {
        public virtual IProduct Product { get; set; }
        public virtual IProduct ParentProduct { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ParentProductId { get; set; }
    }
}

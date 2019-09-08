using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using System.Data.Entity.ModelConfiguration;

namespace SupplyOfProducts.PersistenceDDBB.Configuration
{

    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Product");
        }
    }
}

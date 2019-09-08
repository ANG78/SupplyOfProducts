
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using System.Data.Entity.ModelConfiguration;

namespace SupplyOfProducts.PersistenceDDBB.Configuration
{
    public class PackageConfiguration : EntityTypeConfiguration<Package>
    {
        public PackageConfiguration()
        {

            ToTable("Product");
            Ignore(x => x.Parts);
            
        }
    }
}

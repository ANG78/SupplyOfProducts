using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;

namespace SupplyOfProducts.PersistanceDDBB.Configuration
{
    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {

            builder.ToTable("Product");
            builder.Ignore(x => x.Parts);

        }
    }
}

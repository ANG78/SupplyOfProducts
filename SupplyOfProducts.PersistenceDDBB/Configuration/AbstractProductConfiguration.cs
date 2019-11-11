using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.PersistanceDDBB.Configuration
{
    public class AbstractProductConfiguration : IEntityTypeConfiguration<AbstractProduct>
    {
        public void Configure(EntityTypeBuilder<AbstractProduct> builder)
        {

            builder.ToTable("Product");
            builder.HasDiscriminator(x => x.Class)
            .HasValue<Product>(EStructure.PRODUCT.String())
            .HasValue<Package>(EStructure.PACKAGE.String());

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).IsRequired().HasMaxLength(10);
            builder.Property(c => c.Type).IsRequired().HasMaxLength(10);
            builder.Property(c => c.Class).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Class);


        }
    }
}

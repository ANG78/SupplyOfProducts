
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;

namespace SupplyOfProducts.PersistanceDDBB.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).IsRequired().HasMaxLength(10);
            builder.Property(c => c.Type).IsRequired().HasMaxLength(10);
            builder.Property(c => c.Class).IsRequired().HasMaxLength(10);

        }
    }

}

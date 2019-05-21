
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;

namespace SupplyOfProducts.PersistanceDDBB.Configuration
{
    public class ProductPartsConfiguration : IEntityTypeConfiguration<ProductParts>
    {
        public void Configure(EntityTypeBuilder<ProductParts> builder)
        {
            builder.ToTable("ProductParts");
            builder.HasKey(e => new { e.ParentProductId, e.ProductId });
            
            builder.HasOne(x => x.ParentProduct)
                .WithMany(x => x.PartOfProducts)
                .HasForeignKey(x => x.ParentProductId)
              .IsRequired();

            builder.HasOne(x => x.Product)
               .WithMany(x => x.ParentPartOfProducts)
               .HasForeignKey(x => x.ProductId)
             .IsRequired();


        }
    }

}


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;

namespace SupplyOfProducts.PersistanceDDBB.Configuration
{
    public class ProductPartsConfiguration : IEntityTypeConfiguration<ProductPart>
    {
        public void Configure(EntityTypeBuilder<ProductPart> builder)
        {

            builder.ToTable("ProductParts");
            builder.HasKey(e => new { e.ParentProductId, e.ProductId });



            builder.HasOne(x => (Package)x.ParentProduct)
                .WithMany(x => x.PartOfProducts)
                .HasForeignKey(x => x.ParentProductId)
              .IsRequired();

            builder.HasOne(x => (Product)x.Product)
               .WithMany()
               .HasForeignKey(x => x.ProductId)
             .IsRequired();


        }
    }

}

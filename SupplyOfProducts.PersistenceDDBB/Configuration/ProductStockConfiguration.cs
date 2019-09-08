
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Store;

namespace SupplyOfProducts.PersistanceDDBB.Configuration
{
    public class ProductStockConfiguration : IEntityTypeConfiguration<ProductStock>
    {
        public void Configure(EntityTypeBuilder<ProductStock> builder)
        {
            builder.ToTable("ProductStock");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.BookingId);
            builder.Property(c => c.Code).IsRequired().HasColumnName("PartNumber").HasMaxLength(20);

            builder.Ignore(c => c.IsAvailable);

            builder.HasOne(x => (Product)x.Product).WithMany().HasForeignKey(x=>x.ProductId).IsRequired();
            
        }
    }

    


}

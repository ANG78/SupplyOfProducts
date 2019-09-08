using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Store;
using System.Data.Entity.ModelConfiguration;


namespace SupplyOfProducts.PersistenceDDBB.Configuration
{
    public class ProductStockConfiguration : EntityTypeConfiguration<ProductStock>
    {
        public ProductStockConfiguration()
        {
            ToTable("ProductStock");
            HasKey(c => c.Id);
            Property(c => c.BookingId);
            Property(c => c.Code).IsRequired().HasColumnName("PartNumber").HasMaxLength(20);

            Ignore(c => c.IsAvailable);

            HasRequired(s => (Product)s.Product)
            .WithMany()
            .HasForeignKey<int>(s => s.ProductId);


            //HasOne(x => (Product)x.Product).WithMany().HasForeignKey(x=>x.ProductId).IsRequired();

        }
    }

    


}

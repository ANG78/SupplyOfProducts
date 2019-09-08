
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using System.Data.Entity.ModelConfiguration;

namespace SupplyOfProducts.PersistenceDDBB.Configuration
{
    public class ProductPartsConfiguration : EntityTypeConfiguration<ProductPart>
    {
        public ProductPartsConfiguration()
        {

            ToTable("ProductParts");
            HasKey(e => new { e.ParentProductId, e.ProductId });

            HasRequired(s => (Package)s.ParentProduct)
            .WithMany(x => x.PartOfProducts)
            .HasForeignKey<int>(s => s.ParentProductId);

            HasRequired(s => (Product)s.Product)
            .WithMany()
            .HasForeignKey<int>(s => s.ProductId);

            //HasOne(x => )
            //    .WithMany(x=>x.PartOfProducts)
            //    .HasForeignKey(x => x.ParentProductId)
            //  .IsRequired();

            //HasOne(x => (Product) x.Product)
            //   .WithMany()
            //   .HasForeignKey(x => x.ProductId)
            // .IsRequired();


        }
    }

}

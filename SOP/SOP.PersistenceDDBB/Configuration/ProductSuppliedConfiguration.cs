
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using System.Data.Entity.ModelConfiguration;


namespace SupplyOfProducts.PersistenceDDBB.Configuration
{
    public class ProductSuppliedConfiguration : EntityTypeConfiguration<ProductSupplied>
    {
        public ProductSuppliedConfiguration()
        {
            ToTable("ProductSupplied");
            HasKey(c => c.Id);

            HasRequired(s => (ProductSupplied)s.ProductSupply)
            .WithMany()
            .HasForeignKey<int>(s => s.ProductSupplyId);

            HasRequired(s => (ProductSupplied)s.ProductStock)
            .WithMany()
            .HasForeignKey<int>(s => s.ProductStockId);

            //  HasOne(x => ).WithMany().HasForeignKey(x => x);
            //HasOne(x => (ProductStock)x.ProductStock).WithMany().HasForeignKey(x => x.ProductStockId).IsRequired();
            //HasOne(x => (ProductSupply)x.ProductSupply).WithMany( x=> (IList<ProductSupplied>) x.ProductsSupplied).HasForeignKey(x => x.ProductSupplyId).IsRequired();

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Store;
using System.Collections.Generic;

namespace SupplyOfProducts.PersistanceDDBB.Configuration
{
    public class ProductSuppliedConfiguracion : IEntityTypeConfiguration<ProductSupplied>
    {
        public void Configure(EntityTypeBuilder<ProductSupplied> builder)
        {
            builder.ToTable("ProductSupplied");
            builder.HasKey(c => c.Id);


          //  builder.HasOne(x => (ProductSupplied)x.ParentProductSupplied).WithMany().HasForeignKey(x => x.ParentProductSuppliedId);
            builder.HasOne(x => (ProductStock)x.ProductStock).WithMany().HasForeignKey(x => x.ProductStockId).IsRequired();
            builder.HasOne(x => (ProductSupply)x.ProductSupply).WithMany( x=> (IList<ProductSupplied>) x.ProductsSupplied).HasForeignKey(x => x.ProductSupplyId).IsRequired();

        }
    }
}

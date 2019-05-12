using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using System.Collections.Generic;

namespace SupplyOfProducts.PersistanceDDBB.Configuration
{
    public class ProductSupplyConfiguracion : IEntityTypeConfiguration<ProductSupply>
    {
        public void Configure(EntityTypeBuilder<ProductSupply> builder)
        {
            builder.ToTable("ProductSupply");
            builder.HasKey(c => c.Id);
            builder.Property(x => x.PeriodDate).IsRequired();
            builder.Property(x => x.Date).IsRequired();

            builder.HasOne(x => (Product)x.Product).WithMany().HasForeignKey(x => x.ProductId).IsRequired();
            builder.HasOne(x => (WorkerInWorkPlace)x.WorkerInWorkPlace).WithMany().HasForeignKey(x => x.WorkerInWorkPlaceId).IsRequired();
        }
    }
}

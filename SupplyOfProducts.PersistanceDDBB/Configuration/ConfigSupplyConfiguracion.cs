using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;

namespace SupplyOfProducts.PersistanceDDBB.Configuration
{
    public class ConfigSupplyConfiguracion : IEntityTypeConfiguration<ConfigSupply>
    {
        public void Configure(EntityTypeBuilder<ConfigSupply> builder)
        {
            builder.ToTable("ConfigSupply");
            builder.HasKey(c => c.Id);
            builder.Property(x => x.PeriodDate).IsRequired();
            builder.Property(x => x.Amount).IsRequired();

            builder.HasOne(x => (Product)x.Product).WithMany().HasForeignKey(x=>x.ProductId);
            builder.HasOne(x => (WorkerInWorkPlace)x.WorkerInWorkPlace).WithMany().HasForeignKey(x=>x.WorkerInWorkPlaceId);
            builder.HasOne(x => (SupplyScheduled)x.SupplyScheduled).WithMany().HasForeignKey(x=>x.WorkerInWorkPlaceId);
        }
    }
}

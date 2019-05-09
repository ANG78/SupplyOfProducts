
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;

namespace SupplyOfProducts.PersistanceDDBB.Configuration
{
    public class SupplyScheduledConfiguracion : IEntityTypeConfiguration<SupplyScheduled>
    {
        public void Configure(EntityTypeBuilder<SupplyScheduled> builder)
        {
            builder.ToTable("SupplyScheduled");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Amount).IsRequired();
            builder.Property(c => c.PeriodDate).IsRequired();

            builder.HasOne(x => (Product)x.Product).WithMany().HasForeignKey(x=>x.ProductId).IsRequired();
            builder.HasOne(x => (WorkerInWorkPlace)x.WorkerInWorkPlace).WithMany().HasForeignKey(x => x.WorkerInWorkPlaceId).IsRequired();

            
        }
    }

}

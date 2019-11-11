using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using System.Collections.Generic;

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

            builder.HasOne(x => (AbstractProduct)x.Product).WithMany().HasForeignKey(x => x.ProductId);
            builder.HasOne(x => (WorkerInWorkPlace)x.WorkerInWorkPlace).WithMany().HasForeignKey(x => x.WorkerInWorkPlaceId);
            builder.HasOne(x => (SupplyScheduled)x.SupplyScheduled).WithMany(x => (IList<ConfigSupply>)x.ConfiguratedBy).HasForeignKey(x => x.SupplyScheduledId);
        }
    }
}

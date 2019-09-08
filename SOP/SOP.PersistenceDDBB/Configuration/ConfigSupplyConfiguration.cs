
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace SupplyOfProducts.PersistenceDDBB.Configuration
{
    public class ConfigSupplyConfiguration : EntityTypeConfiguration<ConfigSupply>
    {
        public ConfigSupplyConfiguration()
        {
            ToTable("ConfigSupply");
            HasKey(c => c.Id);
            Property(x => x.PeriodDate).IsRequired();
            Property(x => x.Amount).IsRequired();

            HasRequired(s => (AbstractProduct)s.Product)
            .WithMany()
            .HasForeignKey<int>(s => s.ProductId);

            HasRequired(s => (WorkerInWorkPlace)s.WorkerInWorkPlace)
            .WithMany()
            .HasForeignKey<int>(s => s.WorkerInWorkPlaceId);
            
            HasRequired(s => (SupplyScheduled)s.SupplyScheduled)
            .WithMany(y=> (IList<ConfigSupply>)y.ConfiguratedBy)
            .HasForeignKey<int>(s => s.SupplyScheduledId);

            //HasOne(x => (AbstractProduct)x.Product).WithMany().HasForeignKey(x=>x.ProductId);
            //HasOne(x => ()x.WorkerInWorkPlace).WithMany().HasForeignKey(x=>x.WorkerInWorkPlaceId);
            //HasOne(x => ()x.).WithMany(x=>x.ConfiguratedBy).HasForeignKey(x=>x.SupplyScheduledId);
        }
    }
}


using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using System.Data.Entity.ModelConfiguration;


namespace SupplyOfProducts.PersistenceDDBB.Configuration
{
    public class SupplyScheduledConfiguration : EntityTypeConfiguration<SupplyScheduled>
    {
        public SupplyScheduledConfiguration()
        {
            ToTable("SupplyScheduled");
            HasKey(c => c.Id);
            Property(c => c.Amount).IsRequired();
            Property(c => c.PeriodDate).IsRequired();

            HasRequired(s => (AbstractProduct)s.Product)
           .WithMany()
           .HasForeignKey<int>(s => s.ProductId);

            HasRequired(s => (WorkerInWorkPlace)s.WorkerInWorkPlace)
            .WithMany()
            .HasForeignKey<int>(s => s.WorkerInWorkPlaceId);

            //HasOne(x => (AbstractProduct)x.Product).WithMany().HasForeignKey(x=>x.ProductId).IsRequired();
            //HasOne(x => (WorkerInWorkPlace)x.WorkerInWorkPlace).WithMany().HasForeignKey(x => x.WorkerInWorkPlaceId).IsRequired();


        }
    }

}

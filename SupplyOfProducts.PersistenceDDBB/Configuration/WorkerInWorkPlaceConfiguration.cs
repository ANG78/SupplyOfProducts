using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;


namespace SupplyOfProducts.PersistanceDDBB.Configuration
{

    public class WorkerInWorkPlaceConfiguracion : IEntityTypeConfiguration<WorkerInWorkPlace>
    {
        public void Configure(EntityTypeBuilder<WorkerInWorkPlace> builder)
        {
            builder.ToTable("WorkerInWorkPlace");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DateStart).IsRequired();
            builder.Property(c => c.DateEnd);
            builder.Property(c => c.NumYearsByPeriod).IsRequired();

            builder.HasOne(x=> (Worker)x.Worker).WithMany().HasForeignKey(x => x.WorkerId).IsRequired();
            builder.HasOne(x => (WorkPlace)x.WorkPlace).WithMany().HasForeignKey(x => x.WorkPlaceId).IsRequired();
           
        }
    }
}

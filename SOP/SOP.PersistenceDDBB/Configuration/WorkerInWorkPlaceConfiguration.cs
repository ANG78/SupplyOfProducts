using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using System.Data.Entity.ModelConfiguration;


namespace SupplyOfProducts.PersistenceDDBB.Configuration
{

    public class WorkerInWorkPlaceConfiguration : EntityTypeConfiguration<WorkerInWorkPlace>
    {
        public WorkerInWorkPlaceConfiguration()
        {
            ToTable("WorkerInWorkPlace");
            HasKey(c => c.Id);
            Property(c => c.DateStart).IsRequired();
            Property(c => c.DateEnd);
            Property(c => c.NumYearsByPeriod).IsRequired();

            Ignore(c => c.Worker);
            Ignore(c => c.WorkPlace);


            HasRequired(s => s.WorkerEF)
           .WithMany()
           .HasForeignKey<int>(s => s.WorkerId);

            HasRequired(s => s.WorkPlaceEF)
            .WithMany()
            .HasForeignKey<int>(x => x.WorkPlaceId);

        }
    }
}

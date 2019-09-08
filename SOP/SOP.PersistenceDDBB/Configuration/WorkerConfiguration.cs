using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using System.Linq;
using System.Data.Entity.ModelConfiguration;

namespace SupplyOfProducts.PersistenceDDBB.Configuration
{
    public class WorkerConfiguration : EntityTypeConfiguration<Worker>
    {
        public WorkerConfiguration()
        {
            ToTable("Worker");
            HasKey(c => c.Id);

            Property(c => c.Code)
                .IsRequired()
                .HasMaxLength(10);
         
        }
    }


    
}

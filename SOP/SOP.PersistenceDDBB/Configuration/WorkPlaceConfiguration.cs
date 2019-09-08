using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using System.Data.Entity.ModelConfiguration;



namespace SupplyOfProducts.PersistenceDDBB.Configuration
{
    public class WorkPlaceConfiguration : EntityTypeConfiguration<WorkPlace>
    {
        public WorkPlaceConfiguration()
        {
            ToTable("WorkPlace");
            HasKey(c => c.Id);
            Property(c => c.Code).IsRequired().HasMaxLength(10);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;


namespace SupplyOfProducts.PersistanceDDBB.Configuration
{
    public class WorkPlaceConfiguration : IEntityTypeConfiguration<WorkPlace>
    {
        public void Configure(EntityTypeBuilder<WorkPlace> builder)
        {
            builder.ToTable("WorkPlace");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Code).IsRequired().HasMaxLength(10);
        }
    }
}

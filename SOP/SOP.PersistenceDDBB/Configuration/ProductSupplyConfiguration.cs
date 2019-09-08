
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;


namespace SupplyOfProducts.PersistenceDDBB.Configuration
{
    public class ProductSupplyConfiguration : EntityTypeConfiguration<ProductSupply>
    {
        public ProductSupplyConfiguration()
        {
            ToTable("ProductSupply");
            HasKey(c => c.Id);
            Property(x => x.PeriodDate).IsRequired();
            Property(x => x.Date).IsRequired();

            HasRequired(s => (AbstractProduct)s.Product)
            .WithMany()
            .HasForeignKey<int>(s => s.ProductId);

            HasRequired(s => (WorkerInWorkPlace)s.WorkerInWorkPlace)
            .WithMany()
            .HasForeignKey<int>(s => s.WorkerInWorkPlaceId);
       }
    }
}

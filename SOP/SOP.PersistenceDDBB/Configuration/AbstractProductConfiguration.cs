using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SupplyOfProducts.PersistenceDDBB.Configuration
{
    public class AbstractProductConfiguration : EntityTypeConfiguration<AbstractProduct>
    {
        public AbstractProductConfiguration()
        {

            ToTable("Product")
            .Map<Product>(m => m.Requires("Class").HasValue(EStructure.PRODUCT.String()))
            .Map<Package>(m => m.Requires("Class").HasValue(EStructure.PACKAGE.String()));
            
            HasKey(c => c.Id);
          //  Property(c => c.Id).ValueGeneratedOnAdd();
            Property(c => c.Code).IsRequired().HasMaxLength(10);
            Property(c => c.Type).IsRequired().HasMaxLength(10);
            Property(c => c.Class).IsRequired().HasMaxLength(10);
            Property(x => x.Class);


        } 
    }
}

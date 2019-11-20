using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System.Collections;
using System.Collections.Generic;

namespace SupplyOfProducts.PersistanceDDBB.Configuration
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.ToTable("Worker");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Code)
                .IsRequired()
                .HasMaxLength(10);

            builder.OwnsOne(c => (DetailWork) c.Detail,
                sa =>
                {
                    sa.Property(x => x.Birthday).HasColumnName("Birthday");
                    sa.OwnsOne(c => (AddressWork) c.Address,
                               sa2 =>
                               {
                                   sa2.Property(x=>x.City).HasColumnName("City");
                                   sa2.Property(x => x.Country).HasColumnName("Country");
                                   sa2.Property(x => x.Street).HasColumnName("Street");
                               });
                    sa.Ignore(e => e.Notes);
                    /*e.Notes, eb =>
                    {
                        eb.WithOwner()
                            .HasForeignKey(e => e.Id)
                            .HasConstraintName("FK_OrderDetails");

                        eb.ToTable("Notes");
                        //eb.HasKey(e => e.AlternateId);
                        eb.HasIndex(e => e.Id);

                        eb.HasOne(e => e.Customer).WithOne();

                        eb.HasData(
                            new OrderDetails
                            {
                                AlternateId = 1,
                                Id = -1
                            });
                    });*/

                });

        }
    }



}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SupplyOfProducts.PersistanceDDBB.Configuration;
using System;

namespace SupplyOfProducts.PersistanceDDBB
{
    
    public class SupplyOfProductsContext : DbContext, IGenericContext
    {
        /// <param name="options">The options<see cref="DbContextOptions{SupplyOfProductsContext}"/></param>
        public SupplyOfProductsContext(DbContextOptions<SupplyOfProductsContext> options) : base(options)
        {
      
        }


        /// <summary>
        /// The OnModelCreating
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());
            modelBuilder.ApplyConfiguration(new WorkPlaceConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerInWorkPlaceConfiguracion());
            modelBuilder.ApplyConfiguration(new SupplyScheduledConfiguracion());
            modelBuilder.ApplyConfiguration(new ConfigSupplyConfiguracion());
            modelBuilder.ApplyConfiguration(new ProductStockConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSupplyConfiguracion());
            modelBuilder.ApplyConfiguration(new ProductSuppliedConfiguracion());

        }

        /// <summary>
        /// The GetEntry
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity">The entity<see cref="TEntity"/></param>
        /// <returns>The <see cref="EntityEntry{TEntity}"/></returns>
        public EntityEntry<TEntity> GetEntry<TEntity>(TEntity entity) where TEntity : class
        {
            return Entry(entity);
        }
        
       
        /// <summary>
        /// The GetSet
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>The <see cref="DbSet{TEntity}"/></returns>
        public DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        /// <summary>
        /// The SaveChanges
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception e)
            {

                throw new ApplicationException("DbEntityValidationException thrown during SaveChanges: " + e.Message, e);
            }
        }
        
    }


}

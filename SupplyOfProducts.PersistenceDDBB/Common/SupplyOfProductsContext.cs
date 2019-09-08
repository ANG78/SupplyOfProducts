using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.PersistanceDDBB.Configuration;
using System;
using System.Transactions;

namespace SupplyOfProducts.PersistanceDDBB
{

    public class SupplyOfProductsContext : DbContext, IGenericContext
    {
        public static int IdSupplyOfProductsContextGenerator { get; set; } = 0;

        public int IdContext {get;set;}

        private static object Locker = new object();

        /// <param name="options">The options<see cref="DbContextOptions{SupplyOfProductsContext}"/></param>
        public SupplyOfProductsContext(DbContextOptions<SupplyOfProductsContext> options) : base(options)
        {
            lock(Locker)
            {
                IdSupplyOfProductsContextGenerator++;
                IdContext = IdSupplyOfProductsContextGenerator;
            }
            
        }


        /// <summary>
        /// The OnModelCreating
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AbstractProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new PackageConfiguration());
            
            modelBuilder.ApplyConfiguration(new ProductPartsConfiguration());
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

        public IUnitOfWork CreateUoW()
        {
            return new ScopeTransaction(this);
        }
    }


    public class ScopeTransaction : IUnitOfWork
    {
        protected DbContext _context;
        protected TransactionScope _transaction;

        public ScopeTransaction(DbContext context, IsolationLevel level = IsolationLevel.ReadCommitted)
        {
            _context = context;
            _transaction = new TransactionScope(TransactionScopeOption.Required,
                          new TransactionOptions { IsolationLevel = level });
        }

        /// <summary>
        /// The SaveChanges
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        public int SaveChanges()
        {
            try
            {
                int res = _context.SaveChanges();
                _transaction.Complete();
                return res;
            }
            catch (Exception e)
            {

                throw new ApplicationException("DbEntityValidationException thrown during SaveChanges: " + e.Message, e);
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction.Dispose();
            }
            catch (Exception)
            {

            }
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }

            if (_context != null)
            {
              //  _context.Dispose();
            }

            _transaction = null;
            //_context = null;
        }
    }






}

using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Store;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.PersistenceDDBB.Configuration;
using System;
using System.Data.Entity;
using System.Transactions;

namespace SupplyOfProducts.PersistenceDDBB
{

    public class SupplyOfProductsContext : DbContext, IGenericContext
    {
        public static int IdSupplyOfProductsContextGenerator { get; set; } = 0;


        public DbSet<Product> Product { get; set; }
        //public DbSet<Package> Packages { get; set; }
        public DbSet<ProductPart> ProductParts { get; set; }
        public DbSet<ConfigSupply> ConfigSupply { get; set; }
        public DbSet<ProductStock> ProductStock { get; set; }
        public DbSet<ProductSupply> ProductSupply { get; set; }
        public DbSet<SupplyScheduled> SupplyScheduled { get; set; }
        public DbSet<WorkerInWorkPlace> WorkerInWorkPlace { get; set; }
        public DbSet<Worker> Worker { get; set; }
        public DbSet<WorkPlace> WorkPlace { get; set; }

        
        public int IdContext { get; set; }

        private static object Locker = new object();

        /// <param name="options">The options<see cref="DbContextOptions{SupplyOfProductsContext}"/></param>
        public SupplyOfProductsContext() : base("SupplyOfProducts")
        {
            lock (Locker)
            {
                IdSupplyOfProductsContextGenerator++;
                IdContext = IdSupplyOfProductsContextGenerator;
            }
        }


        /// <summary>
        /// The OnModelCreating
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/></param>

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Configurations.Add(new AbstractProductConfiguration());
            //modelBuilder.Configurations.Add(new ProductConfiguration());
            //modelBuilder.Configurations.Add(new PackageConfiguration());

            //modelBuilder.Configurations.Add(new ProductPartsConfiguration());
            modelBuilder.Configurations.Add(new WorkerConfiguration());
            modelBuilder.Configurations.Add(new WorkPlaceConfiguration());
            modelBuilder.Configurations.Add(new WorkerInWorkPlaceConfiguration());
            //modelBuilder.Configurations.Add(new SupplyScheduledConfiguration());
            //modelBuilder.Configurations.Add(new ConfigSupplyConfiguration());
            //modelBuilder.Configurations.Add(new ProductStockConfiguration());
            //modelBuilder.Configurations.Add(new ProductSupplyConfiguration());
            //modelBuilder.Configurations.Add(new ProductSuppliedConfiguration());

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

        public ScopeTransaction(DbContext context, System.Data.IsolationLevel level = System.Data.IsolationLevel.ReadCommitted)
        {
            _context = context;
            _transaction = new TransactionScope(TransactionScopeOption.Required,
                          new TransactionOptions()/* { IsolationLevel = level }*/);
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

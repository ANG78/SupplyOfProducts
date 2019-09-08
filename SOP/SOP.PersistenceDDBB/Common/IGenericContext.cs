
using SupplyOfProducts.Interfaces.BusinessLogic;
using System.Data.Entity;

namespace SupplyOfProducts.PersistenceDDBB
{

    public interface IGenericContext : ICreateUoW
    {
        int IdContext
        {
            get;
        }
        //DbSet<TEntity> GetEntry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<TEntity> GetSet<TEntity>() where TEntity : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

    }

}

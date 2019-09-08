using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SupplyOfProducts.Interfaces.BusinessLogic;

namespace SupplyOfProducts.PersistanceDDBB
{

    public interface IGenericContext : ICreateUoW
    {
        int IdContext
        {
            get;
        }
        EntityEntry<TEntity> GetEntry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<TEntity> GetSet<TEntity>() where TEntity : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

    }

}

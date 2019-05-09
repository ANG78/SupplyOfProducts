using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace SupplyOfProducts.PersistanceDDBB
{
    public interface IGenericContext
    {
        EntityEntry<TEntity> GetEntry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<TEntity> GetSet<TEntity>() where TEntity : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}

using System.Collections.Generic;

namespace SupplyOfProducts.PersistanceDDBB
{
    public interface IGenericRepository<TEntity>
    {
        /// <summary>
        /// The GetAll
        /// </summary>
        /// <returns>The <see cref="IEnumerable{TEntity}"/></returns>
        IEnumerable<TEntity> GetAll();
        /*
        /// <summary>
        /// The GetById
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="TEntity"/></returns>
        TEntity GetById(TIdKey id);
     
        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/></param>
        void Add(TEntity entity);

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/></param>
        void Delete(TEntity entity);

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/></param>
        void Edit(TEntity entity);

       */
    }
}

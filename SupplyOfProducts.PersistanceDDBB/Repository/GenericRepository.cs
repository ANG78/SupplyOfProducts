using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace SupplyOfProducts.PersistanceDDBB.Repository
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        /// <summary>
        /// Defines the DbContext
        /// </summary>
        protected readonly IGenericContext DbContext;

        /// <summary>
        /// Defines the _objectSet
        /// </summary>
        protected DbSet<TEntity> _Current;

        /// <summary>
        /// 
        /// </summary>
        protected readonly IMapper mapper;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public delegate void ProcedureDelegate(TEntity entity);

        
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbContext">The dbContext<see cref="SupplyOfProductsContext"/></param>
        public GenericRepository(IGenericContext dbContext, IMapper mapper = null)
        {
            DbContext = dbContext;
            _Current = DbContext.Set<TEntity>();
        }

        public virtual TEntity GetById(int id)
        {
            return _Current.Find(id);
        }

        /// <summary>
        /// The GetById
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="TEntity"/></returns>
        public virtual TEntity GetById(string id)
        {
            return _Current.Find(id);
        }

        /// <summary>
        /// The GetById
        /// </summary>
        /// <param name="id">The id<see cref="object[]"/></param>
        /// <returns>The <see cref="TEntity"/></returns>
        public virtual TEntity GetById(params object[] id)
        {
            return _Current.Find(id);
        }

        /// <summary>
        /// The GetAll
        /// </summary>
        /// <returns>The <see cref="IEnumerable{TEntity}"/></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            //Add to list, to execute the query inside of the repo.
            return _Current.AsEnumerable().ToList();
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="predicate">The predicate<see cref="Func{TEntity, bool}"/></param>
        /// <returns>The <see cref="TEntity"/></returns>
        public TEntity Get(Func<TEntity, bool> predicate)
        {
            return _Current.FirstOrDefault(predicate);
        }

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/></param>
        public void Add(TEntity entity)
        {
            _Current.Add(entity);
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/></param>
        public void Delete(TEntity entity)
        {
            _Current.Remove(entity);
        }

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/></param>
        public void Edit(TEntity entity)
        {
            _Current.Attach(entity);
        }

        /// <summary>
        /// The AddRange
        /// </summary>
        /// <param name="entities">The entities<see cref="IEnumerable{TEntity}"/></param>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            _Current.AddRange(entities);
        }

    }
}

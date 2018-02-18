using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AVStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AVStore.DataAccess
{
    public class AbstractRepository<T> : IRepository<T> where T : class, IEntity
    {
        /// <summary>
        ///     The database context for the repository
        /// </summary>
        protected readonly StoreContext Context;

        /// <summary>
        ///     The data set of the repository
        /// </summary>
        protected readonly DbSet<T> DbSet;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AbstractRepository{T}" /> class.
        /// </summary>
        /// <param name="context">The context for the repository</param>
        public AbstractRepository(StoreContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        /// <summary>
        ///     Gets all entities
        /// </summary>
        /// <returns>All entities</returns>
        public IList<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T GetById(object id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        ///     Finds an entity matching the predicate
        /// </summary>
        /// <param name="predicate">The filter clause</param>
        /// <returns>An entity matching the predicate</returns>
        public IList<T> Get(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        /// <summary>
        ///     Determines if there are any entities matching the predicate
        /// </summary>
        /// <param name="predicate">The filter clause</param>
        /// <returns>True if a match was found</returns>
        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public virtual void Update(T entity)
        {
            T entityToUpdate = GetById(entity.Id);

            if (entityToUpdate != null)
            {
                Context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            }
        }

        /// <summary>
        ///     Returns the first entity that matches the predicate else null
        /// </summary>
        /// <param name="predicate">The filter clause</param>
        /// <returns>An entity matching the predicate else null</returns>
        public T Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        /// <summary>
        ///     Adds a given entity to the context
        /// </summary>
        /// <param name="entity">The entity to add to the context</param>
        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>
        ///     Deletes a given entity from the context
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        /// <summary>
        ///     Attaches a given entity to the context
        /// </summary>
        /// <param name="entity">The entity to attach</param>
        public void Attach(T entity)
        {
            DbSet.Attach(entity);
        }
    }
}


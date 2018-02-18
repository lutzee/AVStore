using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AVStore.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        /// <summary>
        ///     Gets all entities.
        /// </summary>
        /// <returns>All entities.</returns>
        IList<T> GetAll();

        /// <summary>
        ///     Returns the first entity that matches the id else null.
        /// </summary>
        /// <param name="id">The id of the entity to be retrieved.</param>
        /// <returns>An entity with a matching id else null.</returns>
        T GetById(object id);

        /// <summary>
        ///     Determines if there are any entities matching the predicate.
        /// </summary>
        /// <param name="predicate">The filter clause.</param>
        /// <returns>True if a match was found.</returns>
        bool Any(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///     Adds a given entity to the context.
        /// </summary>
        /// <param name="entity">The entity to add to the context.</param>
        void Insert(T entity);

        /// <summary>
        ///     Updates an existing record.
        /// </summary>
        /// <param name="entity">The entity to being updated.</param>
        void Update(T entity);

        /// <summary>
        ///     Deletes a given entity from the context.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        void Delete(T entity);

        /// <summary>
        ///     Finds an entity matching the predicate
        /// </summary>
        /// <param name="predicate">The filter clause</param>
        /// <returns>An entity matching the predicate</returns>
        IList<T> Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///     Returns the first entity that matches the predicate else null
        /// </summary>
        /// <param name="predicate">The filter clause</param>
        /// <returns>An entity matching the predicate else null</returns>
        T Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///     Attaches a given entity to the context
        /// </summary>
        /// <param name="entity">The entity to attach</param>
        void Attach(T entity);
    }
}
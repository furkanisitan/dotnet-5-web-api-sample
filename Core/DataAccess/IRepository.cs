using Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        /// <summary>
        /// Finds all the <typeparamref name="TEntity"/> elements based on the <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="includeProperties">The names of the properties to be included.</param>
        /// <returns>A <see cref="ICollection{T}"/> that contains <typeparamref name="TEntity"/> elements.</returns>
        ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, params string[] includeProperties);

        /// <summary>
        /// Finds all the <typeparamref name="TEntity"/> elements.
        /// </summary>
        /// <param name="includeProperties">The names of the properties to be included.</param>
        /// <returns>A <see cref="ICollection{T}"/> that contains <typeparamref name="TEntity"/> elements.</returns>
        ICollection<TEntity> FindAll(params string[] includeProperties);

        /// <summary>
        /// Finds an <typeparamref name="TEntity"/> element based on the <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="includeProperties">The names of the properties to be included.</param>
        /// <returns>The single <typeparamref name="TEntity"/> element that satisfied a specified predicate or <see langword="null"/> if no such element is found.</returns>
        TEntity Find(Expression<Func<TEntity, bool>> predicate, params string[] includeProperties);

        /// <summary>
        /// Adds the <paramref name="entity"/> element to the database.
        /// </summary>
        /// <param name="entity">The entity element to add.</param>
        void Add([NotNull] TEntity entity);

        /// <summary>
        /// Updates the <paramref name="entity"/> element in the database.
        /// </summary>
        /// <param name="entity">The entity element to update.</param>
        void Update([NotNull] TEntity entity);

        /// <summary>
        /// Removes the <paramref name="entity"/> element from the database.
        /// </summary>
        /// <param name="entity">The entity element to delete.</param>
        void Remove([NotNull] TEntity entity);

        /// <summary>
        /// Checks if a <typeparamref name="TEntity"/> element exists based on the <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns><see langword="true"/> if an element exists, otherwise <see langword="false"/>.</returns>
        bool Exists(Expression<Func<TEntity, bool>> predicate);
    }

    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TKey">The type used for the primary key.</typeparam>
    public interface IRepository<TEntity, TKey> : IRepository<TEntity>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Checks whether the specified <paramref name="properties"/> of the <paramref name="entity"/> change according to the values in the database.
        /// </summary>
        /// <param name="entity">The entity element to check.</param>
        /// <param name="properties">The names of the properties to check.</param>
        /// <returns><see langword="true"/> if the value of any property has edited, otherwise <see langword="false"/>.</returns>
        bool IsPropertiesEdited([NotNull] TEntity entity, params string[] properties);
    }
}

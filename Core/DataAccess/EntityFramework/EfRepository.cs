using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public abstract class EfRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, params string[] includeProperties) =>
            _FindAll(predicate, includeProperties);

        public ICollection<TEntity> FindAll(params string[] includeProperties) =>
            _FindAll(null, includeProperties);

        private ICollection<TEntity> _FindAll(Expression<Func<TEntity, bool>> predicate = null, params string[] includeProperties)
        {
            using var context = new TContext();
            var query = context.Set<TEntity>().AsQueryable();

            if (predicate != null) query = query.Where(predicate);

            return includeProperties.Aggregate(query, (current, includeProperty) =>
                current.Include(includeProperty)).ToList();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate, params string[] includeProperties)
        {
            using var context = new TContext();
            var query = context.Set<TEntity>().AsQueryable();

            query = includeProperties.Aggregate(query, (current, includeProperty) =>
                current.Include(includeProperty));

            return query.FirstOrDefault(predicate);
        }

        public virtual void Add(TEntity entity)
        {
            using var context = new TContext();
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            using var context = new TContext();
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual void Remove(TEntity entity)
        {
            using var context = new TContext();
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            using var context = new TContext();
            return context.Set<TEntity>().Any(predicate);
        }
    }

    public abstract class EfRepository<TEntity, TContext, TKey> : EfRepository<TEntity, TContext>, IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TContext : DbContext, new()
        where TKey : IEquatable<TKey>
    {
        public bool IsPropertiesEdited(TEntity entity, params string[] properties)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            if (!properties.Any()) throw new ArgumentException("Input cannot be empty.", nameof(properties));

            using var context = new TContext();
            var tracked = context.Set<TEntity>().SingleOrDefault(x => x.Id.Equals(entity.Id));

            if (tracked == null) throw new ArgumentException("Entity not found.");

            var entry = context.Entry(tracked);
            entry.CurrentValues.SetValues(entity);
            return properties.Any(x => !entry.OriginalValues[x].Equals(entry.CurrentValues[x]));
        }
    }
}

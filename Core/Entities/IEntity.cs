using System;

namespace Core.Entities
{
    public interface IEntity
    {
    }

    /// <typeparam name="TKey">The type used for the primary key.</typeparam>
    public interface IEntity<TKey> : IEntity where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}


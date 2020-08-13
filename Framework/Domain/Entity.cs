using System;

namespace Framework.Domain
{
    public abstract class Entity<TKey, TEntity> : IEquatable<TEntity>
        where TEntity : Entity<TKey, TEntity>
    {
        
        public TKey Id { get;  set; }
        public DateTime CreationDate { get; set; }=DateTime.Now;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public bool Equals(TEntity other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            return base.Equals((TEntity)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

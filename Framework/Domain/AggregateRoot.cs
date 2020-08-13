

namespace Framework.Domain
{
    public class AggregateRoot<TKey, TEntity>: Entity<TKey, TEntity>
        where TEntity : Entity<TKey, TEntity>
    {
     
    }
}

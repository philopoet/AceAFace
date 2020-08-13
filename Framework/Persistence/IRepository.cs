using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.Domain;

namespace Framework.Persistence
{
    public interface IRepository
    {
    }

    public interface IRepository<TKey,TEntity> : IRepository
        where TEntity : Entity<TKey, TEntity>
    {
        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        IList<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);

        IList<TEntity> GetAll();

        void Create(TEntity aggregate);

        void Delete(TEntity aggregate);
    }
}

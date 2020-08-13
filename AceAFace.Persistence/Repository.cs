using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Framework.Domain;
using Framework.Persistence;

namespace AceAFace.Persistence
{
    public abstract class Repository<TKey,TEntity>: IRepository<TKey, TEntity> where TEntity : Entity<TKey, TEntity>
    {
        protected DbContext DbContext;
        protected DbSet<TEntity> EntitySet
        {
            get
            {
                var entitySet = this.DbContext.Set<TEntity>();
                return entitySet;
            }
        }
        protected DbQuery<TEntity> Query
        {
            get
            {
                var includes = GetIncludeExpressions();

                if (!includes.Any())
                {
                    return EntitySet;
                }

                var dbQuery = EntitySet.Include(includes.First());

                foreach (var includeExperssion in includes)
                {
                    dbQuery = dbQuery.Include(includeExperssion);
                }

                return dbQuery;

            }
        }

        protected Repository(IUnitOfWork unitOfWork)
        {
            DbContext = unitOfWork as DbContext;
        }

        public void Create(TEntity entity)
        {
            this.EntitySet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            this.EntitySet.Remove(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = this.Query.First(predicate);
            return entity;
        }

        public IList<TEntity> GetAll()
        {
            var entities = this.Query.ToList();
            return entities;
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = this.Query.Where(predicate).ToList();
            return entities;
        }

        protected abstract IEnumerable<string> GetIncludeExpressions();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Infrastructure;
using Together.DAL.Repository.Abstract;
using Together.DAL.Utils;

namespace Together.DAL.Repository.Concrete
{

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbContext context;
        protected DbSet<TEntity> dbSet;
        public BaseRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            return dbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        public virtual IEnumerable<TEntity> List(QueryParams<TEntity> queryParams)
        {
            return Query(queryParams);
        }

        public virtual TEntity Get(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        protected IEnumerable<TEntity> Query(QueryParams<TEntity> queryParams)
        {
            if (queryParams == null)
                return dbSet.ToList();

            var set = IncludeMultipleProperties(queryParams.IncludeProperties);

            if (queryParams.Predicate != null)
                set = set.Where(queryParams.Predicate);

            if (queryParams.OrderBy != null)
            {
                bool isOrdered;
                IOrderedQueryable<TEntity> sortedSet = OrderQuery(set, queryParams, out isOrdered);

                if (isOrdered)
                    set = LimitQuery(sortedSet, queryParams);
            }

            return set.ToList();
        }

        private IQueryable<TEntity> IncludeMultipleProperties(IEnumerable<string> includeProperties)
        {
            DbQuery<TEntity> query = dbSet;

            foreach (var property in includeProperties ?? Enumerable.Empty<string>())
            {
                query = query.Include(property);
            }

            return query.AsQueryable();
        }

        private IOrderedQueryable<TEntity> OrderQuery(IQueryable<TEntity> query, QueryParams<TEntity> queryParams, out bool isOrdered)
        {
            IOrderedQueryable<TEntity> orderedQuery;

            if (queryParams == null || queryParams.OrderBy==null)
            {
                isOrdered = false;
                return null;
            }

            if (queryParams.OrderDirection == OrderDir.Asc)
            {
                orderedQuery = query.OrderBy(queryParams.OrderBy);
            }
            else
            {
                orderedQuery = query.OrderByDescending(queryParams.OrderBy);
            }

            isOrdered = true;

            return orderedQuery;
        }

        private IQueryable<TEntity> LimitQuery(IOrderedQueryable<TEntity> query, QueryParams<TEntity> queryParams)
        {
            //TODO : ADD MAGIC NUMBERS AS CONSTANTS
            int page = queryParams.Page > 0 ? queryParams.Page : 1;
            int pageSize = queryParams.PageSize > 0 && queryParams.PageSize <= 1000 ? queryParams.PageSize : 10;

            int skip = (page - 1) * pageSize;
            int take = pageSize;

            return query.Skip(skip).Take(take);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Together.DAL.Utils
{
    public static class RepositoryHelper
    {
        static IQueryable<TEntity> IncludeMultipleProperties<TEntity>(this DbSet<TEntity> dbSet,IEnumerable<string> includeProperties)
            where TEntity:class
        {
            DbQuery<TEntity> query = dbSet;

            foreach (var property in includeProperties ?? Enumerable.Empty<string>())
            {
                query = query.Include(property);
            }

            return query.AsQueryable();
        }

        static IOrderedQueryable<TEntity> OrderQuery<TEntity>(IQueryable<TEntity> query, Filter filter, Expression<Func<TEntity,object>> orderBy, out bool isOrdered)
            where TEntity : class 
        {
            IOrderedQueryable<TEntity> orderedQuery;

            if (orderBy == null)
            {
                isOrdered = false;
                return null;
            }

            if (filter.OrderDir == OrderDir.Asc)
            {
                orderedQuery = query.OrderBy(orderBy);
            }
            else
            {
                orderedQuery = query.OrderByDescending(orderBy);
            }

            isOrdered = true;

            return orderedQuery;
        }

        static IQueryable<TEntity> LimitQuery<TEntity>(IOrderedQueryable<TEntity> query, Filter filter)
                        where TEntity : class
        {
            //TODO : ADD MAGIC NUMBERS AS CONSTANTS
            int page = filter.Page > 0 ? filter.Page : 1;
            int pageSize = filter.PageSize > 0 && filter.PageSize <= 1000 ? filter.PageSize : 15;

            int skip = (page - 1) * pageSize;
            int take = pageSize;

            return query.Skip(skip).Take(take);
        }

        public static IQueryable<TEntity> Query<TEntity>(this DbSet<TEntity> dbSet,
            Expression<Func<TEntity, bool>> searchExpression, 
            Expression<Func<TEntity, object>> orderExpression,
            Filter filter, 
            params string[] includeProperties)
            where TEntity : class
        {
            var set = dbSet.IncludeMultipleProperties(includeProperties);

            if (searchExpression != null)
                set = set.Where(searchExpression);

            if (filter != null)
            {
                bool isOrdered;
                IOrderedQueryable<TEntity> sortedSet = OrderQuery(set, filter, orderExpression, out isOrdered);

                if(isOrdered)
                    set = LimitQuery(sortedSet, filter);
            }

            return set;
        }


    }
}

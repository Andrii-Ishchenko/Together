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
	public class BaseRepository<TEntity> : IBaseRepository<TEntity>	where TEntity :class
	{
		protected TogetherDbContext context;
		protected DbSet<TEntity> dbSet;
		public BaseRepository(TogetherDbContext context)
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

		public virtual IEnumerable<TEntity> List(Filter filter)
		{
		    return Query(null,filter,null).ToList();
		}

		public virtual TEntity GetById(int id)
		{
			return dbSet.Find(id);
		}

		public virtual void Update(TEntity entity)
		{
			dbSet.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
		}


	    protected IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> searchExpression, Filter filter, params string[] includeProperties)
	    {
	        var set = IncludeMultipleProperties(includeProperties);
            
	        if (searchExpression != null)
	            set = set.Where(searchExpression);

	        if (filter != null)
	        {
	            bool isOrdered;
                IOrderedQueryable<TEntity> sortedSet = OrderQuery(set, filter, out isOrdered);

                if(isOrdered)
                    set = LimitQuery(sortedSet, filter);
            }

            return set;
	    }

	    private IQueryable<TEntity> IncludeMultipleProperties(IEnumerable<string> includeProperties)
	    {
	        DbQuery<TEntity> query = dbSet;

	        foreach (var property in includeProperties?? Enumerable.Empty<string>())
	        {
	            query = query.Include(property);
	        }

            return query.AsQueryable();
	    }

	    private  IOrderedQueryable<TEntity> OrderQuery(IQueryable<TEntity> query, Filter filter, out bool isOrdered)
	    {       
	        IOrderedQueryable<TEntity> orderedQuery;

            var predicate = GetOrderExpression(filter) ?? GetDefaultOrderExpression();

	        if (predicate == null)
	        {
	            isOrdered = false;
	            return null;
	        }

            if (filter.OrderDir == OrderDir.Asc)
	        {
                orderedQuery = query.OrderBy(predicate);
	        }
	        else
	        {
                orderedQuery = query.OrderByDescending(predicate);
	        }

	        isOrdered = true;

	        return orderedQuery;
	    }

        private IQueryable<TEntity> LimitQuery(IOrderedQueryable<TEntity> query, Filter filter)
        {
            //TODO : ADD MAGIC NUMBERS AS CONSTANTS
            int page = filter.Page > 0 ? filter.Page : 1;
            int pageSize = filter.PageSize > 0 && filter.PageSize <= 1000 ? filter.PageSize : 15;

            int skip = (page - 1) * pageSize;
            int take = pageSize;

            return query.Skip(skip).Take(take);
        }

        protected virtual Expression<Func<TEntity, bool>> GetOrderExpression(Filter filter)
        {
            return null;
        }

	    protected virtual Expression<Func<TEntity, bool>> GetDefaultOrderExpression()
	    {
	        return null;
	    }


	}
}

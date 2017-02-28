using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Infrastructure.Concrete;
using Together.DAL.Repository.Abstract;

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

		public virtual IEnumerable<TEntity> List()
		{
			return dbSet.ToList();
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


	    protected IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params string[] includeProperties)
	    {
	        var set = IncludeMultipleProperties(includeProperties);

	        if (predicate != null)
	            return set.Where(predicate);

            return set;
	    }

	    protected DbQuery<TEntity> IncludeMultipleProperties(IEnumerable<string> includeProperties)
	    {
	        DbQuery<TEntity> query = dbSet;

	        foreach (var property in includeProperties?? Enumerable.Empty<string>())
	        {
	            query = query.Include(property);
	        }

            return query;
	    } 
	}
}

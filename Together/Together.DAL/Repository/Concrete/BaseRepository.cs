using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Infrastructure.Concrete;
using Together.DAL.Repository.Abstract;

namespace Together.DAL.Repository.Concrete
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity>	where TEntity :class
	{
		private TogetherDbContext context;
		private DbSet<TEntity> dbSet;
		public BaseRepository(TogetherDbContext context)
		{
			this.context = context;
			dbSet = context.Set<TEntity>();

		}

		public TEntity Add(TEntity entity)
		{
			return dbSet.Add(entity);
	
		}

		public void Delete(TEntity entity)
		{
			if (context.Entry(entity).State == EntityState.Detached)
			{
				dbSet.Attach(entity);
			}

			dbSet.Remove(entity);
		}

		public IEnumerable<TEntity> Get()
		{
			return dbSet;
		}

		public TEntity GetById(int id)
		{
			return dbSet.Find(id);
		}

		public void SaveChanges()
		{
			context.SaveChanges();
		}

		public void Update(TEntity entity)
		{
			dbSet.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
		}
	}
}

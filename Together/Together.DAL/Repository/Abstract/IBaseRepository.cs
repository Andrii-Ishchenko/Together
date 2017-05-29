using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Utils;

namespace Together.DAL.Repository.Abstract
{
    public interface IRepository{}

	public interface IBaseRepository<TEntity> : IRepository
		where TEntity : class
	{
		TEntity Get(int id);

		IEnumerable<TEntity> List(QueryParams<TEntity> queryParams);

		TEntity Add(TEntity entity);

		void Update(TEntity entity);

		void Delete(TEntity entity);

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Utils;

namespace Together.DAL.Repository.Abstract
{
	public interface IBaseRepository<TEntity>
		where TEntity : class
	{
		TEntity GetById(int id);

		IEnumerable<TEntity> List(Filter filter);

		TEntity Add(TEntity Entity);

		void Update(TEntity Entity);

		void Delete(TEntity Entity);

	    Expression<Func<TEntity, object>> GetOrderExpression(Filter filter);

	    Expression<Func<TEntity, bool>> GetSearchExpression(Filter filter);

	}
}

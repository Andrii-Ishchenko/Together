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
		TEntity Get(int id);

		IEnumerable<TEntity> List(QueryParams<TEntity> queryParams);

		TEntity Add(TEntity Entity);

		void Update(TEntity Entity);

		void Delete(TEntity Entity);

	}
}

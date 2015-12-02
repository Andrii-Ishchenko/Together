using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.DAL.Repository.Abstract
{
	public interface IBaseRepository<TEntity>
		where TEntity : class
	{
		TEntity GetById(int id);

		IEnumerable<TEntity> Get();

		TEntity Add(TEntity Entity);

		void Update(TEntity Entity);

		void Delete(TEntity Entity);
	}
}

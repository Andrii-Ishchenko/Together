using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.BL.Services.Abstract
{
	public interface IBaseService<TEntity>
		where TEntity : class
	{		
		 TEntity GetById(int id);

         IEnumerable<TEntity> GetAll();

         TEntity Add(TEntity entity);

         void Delete(TEntity entity);

         void Update(TEntity entity);

	}
}

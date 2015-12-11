using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL.Services.Abstract;

namespace Together.BL.Services.Concrete
{
	public class BaseService<TEntityDto,TEntity> : IBaseService<TEntityDto>
		where TEntityDto : class
	{
		public TEntityDto Add(TEntityDto entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(TEntityDto entity)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TEntityDto> GetAll()
		{
			throw new NotImplementedException();
		}

		public TEntityDto GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(TEntityDto entity)
		{
			throw new NotImplementedException();
		}
	}
}

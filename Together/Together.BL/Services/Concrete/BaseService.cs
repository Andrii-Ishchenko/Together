using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL.Services.Abstract;
using Together.DAL.Repository.Abstract;

namespace Together.BL.Services.Concrete
{
	public abstract class BaseService<TEntityDto,TEntity> : IBaseService<TEntityDto>
		where TEntityDto : class
		where TEntity: class
	{
		//should be moved to uow
		IBaseRepository<TEntity> _repository;

		public BaseService()
		{

		}

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

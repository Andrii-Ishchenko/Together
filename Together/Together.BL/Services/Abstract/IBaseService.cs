using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.BL.Services.Abstract
{
	public interface IBaseService<TEntityDto>
		where TEntityDto : class
	{		
		 TEntityDto GetById(int id);

         IEnumerable<TEntityDto> GetAll();

         TEntityDto Add(TEntityDto entity);

         void Delete(TEntityDto entity);

         void Update(TEntityDto entity);

	}
}

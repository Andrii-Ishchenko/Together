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
        TEntityDto GetById<TEntityDto>(int id)
            where TEntityDto : class;

        IEnumerable<TEntityDto> GetAll<TEntityDto>()
            where TEntityDto : class;

        TEntityDto Add<TEntityDto>(TEntityDto entityDto)
            where TEntityDto : class;

        void Delete<TEntityDto>(TEntityDto entityDto)
            where TEntityDto : class;

        void Update<TEntityDto>(TEntityDto entityDto)
            where TEntityDto : class;

    }
}

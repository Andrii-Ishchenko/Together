using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Utils;

namespace Together.BL.Services.Abstract
{
    public interface IBaseService<TEntity>
        where TEntity : class
    {
        TEntity GetById(int id);

        IEnumerable<TEntity> Get(Filter filter);

        TEntity Add(TEntity entityDto);

        void Delete(int id);

        void Update(TEntity entityDto);


    }
}

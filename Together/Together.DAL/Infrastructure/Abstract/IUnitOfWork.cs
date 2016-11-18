using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Repository.Abstract;

namespace Together.DAL.Infrastructure.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
        void Save();

        IBaseRepository<T> GetRepository<T>() 
            where T : class;
    }
}

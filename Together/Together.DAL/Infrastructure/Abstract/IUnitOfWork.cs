using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Repository.Abstract;

namespace Together.DAL.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRouteRepository RouteRepository { get; }
        IRoutePointRepository RoutePointRepository { get; }

        IBaseRepository<T> Repository<T>() 
            where T : class;

        void Save();
    }
}

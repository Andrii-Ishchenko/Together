using System;
using Together.DAL.Repository;

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

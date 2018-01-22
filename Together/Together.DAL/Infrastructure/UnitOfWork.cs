using System;
using System.Collections.Generic;
using Together.DAL.Repository;

namespace Together.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TogetherDbContext _context;
        private Dictionary<string, object> _repositories;

        public UnitOfWork()
        {
            _context = new TogetherDbContext();
            _repositories = new Dictionary<string, object>();
        }

        #region Dispose

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        #endregion

        public IRouteRepository RouteRepository => new RouteRepository(_context);

        public IRoutePointRepository RoutePointRepository => new RoutePointRepository(_context);

        /// <summary>
        /// Creates BaseRepository(only for CRUD operations)
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IBaseRepository<TEntity> Repository<TEntity>()
            where TEntity: class
        {
            return new BaseRepository<TEntity>(_context);
        } 

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

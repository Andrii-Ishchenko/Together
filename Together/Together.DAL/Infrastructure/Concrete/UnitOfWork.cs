using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Repository.Abstract;
using Together.DAL.Repository.Concrete;

namespace Together.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TogetherDbContext _context;

        public UnitOfWork(TogetherDbContext context)
        {
            _context = context;
        }

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

       
        public IRouteRepository RouteRepository
        {
            get
            {
                return new RouteRepository(_context);
            }
        }

        public IRoutePointRepository RoutePointRepository
        {
            get
            {
                return new RoutePointRepository(_context);
            }
        }
            
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

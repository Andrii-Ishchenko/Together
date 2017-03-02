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
        private readonly TogetherDbContext _context = new TogetherDbContext();

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

        public IBaseRepository<T> Repository<T>() where T : class
        {
            return new BaseRepository<T>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Infrastructure.Abstract;
using Together.DAL.Repository.Abstract;
using Together.DAL.Repository.Concrete;

namespace Together.DAL.Infrastructure.Concrete
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private TogetherDbContext _context = new TogetherDbContext();
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            disposed = true;
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

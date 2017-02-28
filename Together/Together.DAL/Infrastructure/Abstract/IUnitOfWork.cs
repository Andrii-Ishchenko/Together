using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Infrastructure.Concrete;
using Together.DAL.Repository.Abstract;

namespace Together.DAL.Infrastructure.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        TogetherDbContext DbContext { get; }
        void Save();
    
    }
}

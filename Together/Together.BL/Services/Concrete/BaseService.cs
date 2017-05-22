using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL.Services.Abstract;
using Together.BL.Utils;
using Together.DAL.Infrastructure;
using Together.DAL.Repository.Abstract;
using Together.DAL.Utils;

namespace Together.BL.Services.Concrete
{
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class
    {
        protected readonly IUnitOfWorkFactory _factory;
        private IBaseRepository<TEntity> repository; 

        public BaseService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public virtual TEntity Add(TEntity entity)
        {
            using (IUnitOfWork uow = _factory.Create())
            {
                var repository = uow.Repository<TEntity>();
                var added = repository.Add(entity);
                uow.Save();
                return added;
            }
        }

        public virtual void Delete(int id)
        {
            using (IUnitOfWork uow = _factory.Create())
            {
                var repository = uow.Repository<TEntity>();
                var entity = repository.Get(id);

                if (entity != null)
                {
                    repository.Delete(entity);
                    uow.Save();
                }
            }         
        }

        public virtual IEnumerable<TEntity> List(Filter filter)
        {
            using (IUnitOfWork uow = _factory.Create())
            {
                var repository = uow.Repository<TEntity>();
                return repository.List(filter);
            }
        }

        public virtual TEntity Get(int id)
        {

            using (IUnitOfWork uow = _factory.Create())
            {
                var repository = uow.Repository<TEntity>();
                return repository.Get(id);
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (IUnitOfWork uow = _factory.Create())
            {
                var repository = uow.Repository<TEntity>();
                repository.Update(entity);
                uow.Save();
            }
        }

    }
}

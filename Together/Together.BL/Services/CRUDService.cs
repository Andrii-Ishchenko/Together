using System.Collections.Generic;
using Together.BL.Utils;
using Together.DAL.Infrastructure;
using Together.DAL.Utils;

namespace Together.BL.Services
{
    public class CRUDService<TEntity> : ICRUDService<TEntity>
        where TEntity : class
    {
        protected readonly IUnitOfWorkFactory _factory;
       
        public CRUDService(IUnitOfWorkFactory factory)
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
                var query = GetQueryParams(filter);
                return repository.List(query);
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

        protected virtual QueryParams<TEntity> GetQueryParams(Filter filter)          
        {
            return null;
        }
    }
}

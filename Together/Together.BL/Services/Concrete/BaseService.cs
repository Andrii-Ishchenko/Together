using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL.Services.Abstract;
using Together.DAL.Infrastructure;
using Together.DAL.Repository.Abstract;
using Together.DAL.Utils;

namespace Together.BL.Services.Concrete
{
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class
    {
        protected readonly IUnitOfWorkFactory factory;

        public BaseService(IUnitOfWorkFactory uowFactory)
        {
            factory = uowFactory;        
        }

        public virtual TEntity Add(TEntity entity)
        {        
            using(IUnitOfWork uow = factory.Create())
            {
                var repository = uow.Repository<TEntity>();
                var added = repository.Add(entity);
                uow.Save();
                return added;
            }

        }

        public virtual void Delete(int id)
        {
            using (IUnitOfWork uow = factory.Create())
            {
                var repository = uow.Repository<TEntity>();
                var entity = repository.GetById(id);

                if (entity != null)
                {
                    repository.Delete(entity);
                    uow.Save();
                }
            }
          
        }

        public virtual IEnumerable<TEntity> Get(Filter filter)
        {
            using (IUnitOfWork uow = factory.Create())
            {
                var repository = uow.Repository<TEntity>();
                return repository.List(filter);
            }
        }

        public virtual TEntity GetById(int id)
        {

            using (IUnitOfWork uow = factory.Create())
            {
                var repository = uow.Repository<TEntity>();
                return repository.GetById(id);
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (IUnitOfWork uow = factory.Create())
            {
                var repository = uow.Repository<TEntity>();
                repository.Update(entity);
                uow.Save();
            }
        }

    }
}

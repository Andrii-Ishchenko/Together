using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL.Services.Abstract;
using Together.DAL.Infrastructure.Abstract;
using Together.DAL.Repository.Abstract;

namespace Together.BL.Services.Concrete
{
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IUnitOfWorkFactory _factory;

        public BaseService(IBaseRepository<TEntity> repository, IUnitOfWorkFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public virtual TEntity Add(TEntity entity)
        {
            using (var uow = _factory.Create())
            {

                var added = _repository.Add(entity);
                uow.Save();
                return added;
            }
        }



        public virtual void Delete(int id)
        {
            using (var uow = _factory.Create())
            {
               var entity = _repository.GetById(id);

                if (entity!=null)
                {
                    _repository.Delete(entity);
                    uow.Save();
                }
            }

        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            using (var uow = _factory.Create())
            {              
                return _repository.List();
            }
        }

        public virtual TEntity GetById(int id)
        {
            using (var uow = _factory.Create())
            {             
                return _repository.GetById(id);
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (var uow = _factory.Create())
            {
                _repository.Update(entity);
                uow.Save();
            }
        }

    }
}

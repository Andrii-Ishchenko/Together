using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL.Services.Abstract;
using Together.DAL.Infrastructure.Abstract;
namespace Together.BL.Services.Concrete
{
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class
    {
        protected readonly IUnitOfWorkFactory _factory;

        public BaseService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public TEntity Add(TEntity entity)
        {
            using (var uow = _factory.Create())
            {
                var repo = uow.Repository<TEntity>();

                return repo.Add(entity);
            }
        }



        public void Delete(int id)
        {
            using (var uow = _factory.Create())
            {
                var repo = uow.Repository<TEntity>();
                var entity = repo.GetById(id);

                if (entity!=null)
                {
                    repo.Delete(entity);
                }
            }

        }

        public IEnumerable<TEntity> GetAll()
        {
            using (var uow = _factory.Create())
            {
                var repo = uow.Repository<TEntity>();

                return repo.Get();
            }
        }



        public TEntity GetById(int id)
        {
            using (var uow = _factory.Create())
            {
                var repo = uow.Repository<TEntity>();

                return repo.GetById(id);
            }
        }

        public void Update(TEntity entity)
        {
            using (var uow = _factory.Create())
            {
                var repo = uow.Repository<TEntity>();

                repo.Update(entity);
            }
        }

    }
}

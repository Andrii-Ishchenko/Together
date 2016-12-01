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
        //protected readonly IUnitOfWorkFactory _factory;

        //TODO : mark as internal

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        
        }

        public virtual TEntity Add(TEntity entity)
        {        
            var added = _repository.Add(entity);  
            _repository.SaveChanges();
            return added;
        }

        public virtual void Delete(int id)
        {         
            //TODO : add exist() method
            var entity = _repository.GetById(id);

            if (entity!=null)
            {
                _repository.Delete(entity);
            }
            
        }

        public virtual IEnumerable<TEntity> GetAll()
        {                     
            return _repository.List();           
        }

        public virtual TEntity GetById(int id)
        {
                      
            return _repository.GetById(id);
        }

        public virtual void Update(TEntity entity)
        {
           
            _repository.Update(entity);
            _repository.SaveChanges();                       
        }

    }
}

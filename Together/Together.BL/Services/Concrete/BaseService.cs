using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL.Services.Abstract;
using Together.DAL.Infrastructure.Abstract;
using AutoMapper;
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

        public TEntityDto Add<TEntityDto>(TEntityDto entityDto) where TEntityDto : class
        {
            using (var uow = _factory.Create())
            {
                var entity = Mapper.Map<TEntityDto, TEntity>(entityDto);

                var newEntity = uow.Repository<TEntity>().Add(entity);

                return Mapper.Map<TEntity, TEntityDto>(newEntity);
            }
        }

        public void Delete<TEntityDto>(TEntityDto entityDto) where TEntityDto : class
        {
            using(var uow = _factory.Create())
            {
                var entity = Mapper.Map<TEntityDto, TEntity>(entityDto);

                uow.Repository<TEntity>().Delete(entity);
            }
        }

        public IEnumerable<TEntityDto> GetAll<TEntityDto>() where TEntityDto : class
        {
            IEnumerable<TEntityDto> output;

            using (var uow = _factory.Create())
            {
                var list = uow.Repository<TEntity>().Get();

                output = list.Select(e => Mapper.Map<TEntity, TEntityDto>(e));               
            }

            return output;
        }

        public TEntityDto GetById<TEntityDto>(int id) where TEntityDto : class
        {
            using (var uow = _factory.Create())
            {
                var entity = uow.Repository<TEntity>().GetById(id);

                return Mapper.Map<TEntity, TEntityDto>(entity);
            }
        }

        public void Update<TEntityDto>(TEntityDto entityDto) where TEntityDto : class
        {
            using (var uow = _factory.Create())
            {
                var entity = Mapper.Map<TEntityDto, TEntity>(entityDto);

                uow.Repository<TEntity>().Update(entity);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Together.BL.Services.Abstract;
using Together.DAL.Infrastructure.Abstract;
using Together.DAL.Repository.Abstract;
using Together.Domain.Entities;

namespace Together.BL.Services.Concrete
{
    public class PointService : BaseService<Point>, IPointService
    {
        public PointService(IUnitOfWorkFactory uowFactory) : base(uowFactory)
        {
        }

        public Point Zero()
        {
            using(IUnitOfWork uow = factory.Create())
            {
                var repository = (IPointRepository)(uow.Repository<Point>());
                return repository.ClosestToZero();
            }
        }
    }
}

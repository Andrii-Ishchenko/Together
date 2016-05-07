using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL.Services.Abstract;
using Together.DAL.Infrastructure.Abstract;
using Together.Domain.Entities;

namespace Together.BL.Services.Concrete
{
    public class PointService : BaseService<Point>, IPointService
    {
        public PointService(IUnitOfWorkFactory factory)
            :base(factory)
        {
            
        }
    }
}

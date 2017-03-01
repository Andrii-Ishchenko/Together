using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Entities;

namespace Together.DAL.Repository.Abstract
{
    public interface IPointRepository : IBaseRepository<Point>
    {
         Point ClosestToZero();
    }
}

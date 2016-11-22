using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Infrastructure.Concrete;
using Together.DAL.Repository.Abstract;
using Together.Domain.Entities;

namespace Together.DAL.Repository.Concrete
{
    public class PointRepository : BaseRepository<Point>, IPointRepository
    {
        public PointRepository(TogetherDbContext context) : base(context)
        {
                
        }

        public Point ClosestToZero()
        {
            var min = dbSet.Min(p => p.Longitude*p.Longitude + p.Latitude*p.Latitude);

            return dbSet.First(p => p.Longitude*p.Longitude + p.Latitude*p.Latitude <= min);
        }
    }
}

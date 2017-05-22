using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Infrastructure;
using Together.DAL.Repository.Abstract;
using Together.DAL.Utils;
using Together.Domain;

namespace Together.DAL.Repository.Concrete
{
    public class RoutePointRepository : BaseRepository<RoutePoint>, IRoutePointRepository
    {
        public RoutePointRepository(TogetherDbContext context)
            :base(context)
        {
            this.context = context;
            dbSet = context.Set<RoutePoint>();
        }

        private Expression<Func<RoutePoint, object>> GetOrderExpression(string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy))
                return x => x.Id;

            return x => x.ListOrder;
        }

        private Expression<Func<RoutePoint, bool>> GetSearchExpression()
        {
            return null;
        }
    }
}

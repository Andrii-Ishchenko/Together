using System;
using System.Data.Entity;
using System.Linq.Expressions;
using Together.Domain;

namespace Together.DAL.Repository
{
    public class RoutePointRepository : BaseRepository<RoutePoint>, IRoutePointRepository
    {
        public RoutePointRepository(DbContext context)
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

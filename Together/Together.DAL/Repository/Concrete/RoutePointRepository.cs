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
    public class RoutePointRepository : IRoutePointRepository
    {
        private TogetherDbContext context;
        private DbSet<RoutePoint> dbSet;


        public RoutePointRepository(TogetherDbContext context)
        {
            this.context = context;
        }

        public RoutePoint GetById(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<RoutePoint> List(Filter filter)
        {
            return dbSet.Query(GetSearchExpression(filter), GetOrderExpression(filter), filter).ToList();
        }

        public RoutePoint Add(RoutePoint routePoint)
        {
            return dbSet.Add(routePoint);
        }

        public void Update(RoutePoint routePoint)
        {
            dbSet.Attach(routePoint);
            context.Entry(routePoint).State = EntityState.Modified;
        }

        public void Delete(RoutePoint routePoint)
        {
            if (context.Entry(routePoint).State == EntityState.Detached)
            {
                dbSet.Attach(routePoint);
            }

            dbSet.Remove(routePoint);
        }

        public Expression<Func<RoutePoint, object>> GetOrderExpression(Filter filter)
        {
            if (string.IsNullOrEmpty(filter?.OrderBy))
                return x => x.Id;

            return x => x.ListOrder;

        }

        public Expression<Func<RoutePoint, bool>> GetSearchExpression(Filter filter)
        {
            return null;
        }
    }
}

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
    public class RouteRepository : IRouteRepository
    {
        private TogetherDbContext context;
        private DbSet<Route> dbSet;

        public RouteRepository(TogetherDbContext context)
        {
            this.context = context;
            this.dbSet = context.Routes;
        }

        public Route GetById(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<Route> List(Filter filter)
        {
            return dbSet.Query(GetSearchExpression(filter),GetOrderExpression(filter), filter, "RoutePoint", "RouteUser", "Owner").ToList();
        }

        public Route Add(Route route)
        {
            return dbSet.Add(route);
        }

        public void Update(Route route)
        {
            dbSet.Attach(route);
            context.Entry(route).State = EntityState.Modified;
        }

        public void Delete(Route route)
        {
            if (context.Entry(route).State == EntityState.Detached)
            {
                dbSet.Attach(route);
            }

            dbSet.Remove(route);
        }

        public Expression<Func<Route, object>> GetOrderExpression(Filter filter)
        {
            if (string.IsNullOrEmpty(filter?.OrderBy))
                return x => x.StartDate;

            switch (filter.OrderBy)
            {               
                case "CreateDate":
                    return x => x.CreateDate;
                case "MaxPassengers":
                    return x => x.MaxPassengers;
                case "StartDate":
                default:
                    return x => x.StartDate;              
            }
        }

        public Expression<Func<Route, bool>> GetSearchExpression(Filter filter)
        {
            return null;
        } 
    }
}

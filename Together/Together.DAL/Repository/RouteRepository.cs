using System;
using System.Data.Entity;
using System.Linq.Expressions;
using Together.Domain;

namespace Together.DAL.Repository
{
    public class RouteRepository : BaseRepository<Route>, IRouteRepository
    {
        public RouteRepository(DbContext context) : base(context)
        {
        }

        private Expression<Func<Route, object>> GetOrderExpression(string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy))
                return x => x.StartDate;

            switch (orderBy)
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
    }
}

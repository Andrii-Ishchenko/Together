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

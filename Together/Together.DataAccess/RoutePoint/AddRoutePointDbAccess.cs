using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.Data.Context;
using Domain = Together.Data.Domain;


namespace Together.DataAccess.RoutePoint
{
    public interface IAddRoutePointDbAccess
    {
        Domain.RoutePoint AddRoutePoint(Domain.RoutePoint routePoint);
        bool RouteExist(int routeId);
    }

    public class AddRoutePointDbAccess : IAddRoutePointDbAccess
    {
        private TogetherDbContext _context;
        
        public AddRoutePointDbAccess(TogetherDbContext context)
        {
            _context = context;
        }

        public bool RouteExist(int routeId)
        {
            return _context.Routes.Any(r => r.Id == routeId);
        }

        public Domain.RoutePoint AddRoutePoint(Domain.RoutePoint routePoint)
        {
            return _context.RoutePoints.Add(routePoint);
        }
    }
}

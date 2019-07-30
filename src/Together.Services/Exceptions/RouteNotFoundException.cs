using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Services.Exceptions
{
    public class RouteNotFoundException : Exception
    {
        int _routeId;

        public RouteNotFoundException(int routeId)
        {
            _routeId = routeId;
        }

        public override string ToString()
        {
            return $"Route not found. RouteId = {_routeId}";
        }
    }
}

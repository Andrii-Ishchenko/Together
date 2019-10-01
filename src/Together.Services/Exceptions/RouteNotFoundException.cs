using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Services.Exceptions
{
    public class RouteNotFoundException : BusinessException
    {
        public RouteNotFoundException(int routeId) 
            : base($"Route not found. RouteId = {routeId}")
        {
        }

    }
}

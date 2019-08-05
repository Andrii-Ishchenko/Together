using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Together.DataAccess;
using Together.Services;
using Together.Services.Requests;

namespace Together.WebApi.Controllers
{
    public class RoutePointsController : ApiController
    {
        private readonly IRoutePointService _routePointService;

        public RoutePointsController(IRoutePointService routePointService)
        {
            _routePointService = routePointService;
        }

        [Route("api/routes/{routeId}/routepoints")]
        [HttpPost]
        public IHttpActionResult AddRoutePoint(int routeId, CreateRoutePointRequest request)
        {
            //Additional mapping just in case.
            request.RouteId = routeId;
            
            var routePoint = _routePointService.AddPointToRoute(request);

            return Ok(routePoint);
        }
    }
}
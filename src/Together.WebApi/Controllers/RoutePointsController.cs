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
        private readonly RoutePointService _routePointsService;

        public RoutePointsController()
        {
            var factory = new TogetherDbContextFactory();
            var userService = new UserService(factory);
            var routeService = new RouteService(factory);
            _routePointsService = new RoutePointService(factory, routeService, userService);
        }

        [Route("api/routes/{routeId}/routepoints")]
        [HttpPost]
        public IHttpActionResult AddRoutePoint(int routeId, CreateRoutePointRequest request)
        {
            //Additional mapping just in case.
            request.RouteId = routeId;
            
            var routePoint = _routePointsService.AddPointToRoute(request);

            return Ok(routePoint);
        }
    }
}
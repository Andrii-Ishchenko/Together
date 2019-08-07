using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Together.DataAccess;
using Together.Services;
using Together.Services.Functions;
using Together.Services.Interfaces;
using Together.Services.Requests;

namespace Together.WebApi.Controllers
{
    public class RoutesController : ApiController
    {
        public IRouteService _routeService;
        private readonly ICreateRoute _createRoute;

        public RoutesController(IRouteService routeService, ICreateRoute createRoute)
        {
            _routeService = routeService;
            _createRoute = createRoute;
        }

        [HttpGet]
        public IHttpActionResult GetRoutes()
        {
            var list = _routeService.List();
            return Ok(list);           
        }

        [HttpPost]
        public IHttpActionResult CreateRoute(CreateRouteRequest request)
        {
            try
            {
               return Ok(_createRoute.Create(request));
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}

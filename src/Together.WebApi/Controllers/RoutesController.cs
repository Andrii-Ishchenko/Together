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

namespace Together.WebApi.Controllers
{
    public class RoutesController : ApiController
    {
        public IRouteService _routeService;
        public RoutesController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public IHttpActionResult GetRoutes()
        {
            var list = _routeService.List();
            return Ok(list);           
        }
    }
}

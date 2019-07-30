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
        public RoutesController()
        {
            //inject Route service
            _routeService = new RouteService(new TogetherDbContextFactory());
        }

        [HttpGet]
        public IHttpActionResult GetRoutes()
        {
            /*
             TogetherDbContext db = new TogetherDbContext();
             var list = db.Routes.Include(r => r.Passengers.Select(p=>p.User)).ToList();
             */

            var list = _routeService.List();

            return Ok(list);
            
        }

    }
}

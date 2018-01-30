using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using Together.Services.Route;
using Together.Services.Route.DTO;


namespace Together.WebApi.Controllers
{
    public class RoutesController : ApiController
    {
        private readonly IRouteCRUDService _routeService;

        public RoutesController(IRouteCRUDService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public List<RouteListDTO> Get()
        {
            var query = _routeService.GetAll();
            return query.ToList();
        }

    }
}

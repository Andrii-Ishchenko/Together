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
            return _routeService.GetAll();
        }

        [HttpGet]
        public RouteDTO Get(int id)
        {
            return _routeService.Get(id);
        }
    }
}

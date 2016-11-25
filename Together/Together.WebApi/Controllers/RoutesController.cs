using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Together.BL.Services.Abstract;
using Together.Domain.Entities;

namespace Together.WebApi.Controllers
{
    public class RoutesController : ApiController
    {
        private readonly IRouteService _routeService;

        public RoutesController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public IEnumerable<Route> Get()
        {
            return _routeService.GetAll();
        }



        [HttpPost]
        public void Add(Route r)
        {
            _routeService.Add(r);
        }  
    }
}

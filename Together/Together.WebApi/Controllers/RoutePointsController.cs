using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Together.BL.DTO;
using Together.BL.Services.Abstract;


namespace Together.WebApi.Controllers
{
    public class RoutePointsController : ApiController
    {
        private readonly IRoutePointService _routePointService;
        private readonly IRouteService _routeService;

        public RoutePointsController(IRoutePointService routePointService, IRouteService routeService)
        {
            _routePointService = routePointService;
            _routeService = routeService;
        }

        [HttpPost]
        [ActionName("AddToRoute")]
        public void AddPointToRoute(CreateRoutePointModel model)
        {
            if (model == null)
                throw new HttpRequestException("Model is null");

            _routePointService.AddPointToRoute(model);


        }
    }
}

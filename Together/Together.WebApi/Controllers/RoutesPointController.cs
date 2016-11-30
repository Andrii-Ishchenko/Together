using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Together.BL.DTOModels;
using Together.BL.Services.Abstract;


namespace Together.WebApi.Controllers
{
    public class RoutesPointController : ApiController
    {
        private readonly IRoutePointService _routePointService;
        private readonly IRouteService _routeService;

        public RoutesPointController(IRoutePointService routePointService, IRouteService routeService)
        {
            _routePointService = routePointService;
            _routeService = routeService;
        }

        public void AddPointToRoute(AddPointToRouteModel model)
        {
            if (model == null)
                throw new HttpRequestException("Model is null");

           

        }
    }
}

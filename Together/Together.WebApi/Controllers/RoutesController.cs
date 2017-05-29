using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Together.BL.DTO;

using Together.BL.Services.Abstract;
using Together.BL.Utils;
using Together.DAL.Utils;
using Together.Domain;


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
        public IEnumerable<ListRouteModel> Get([FromUri]Filter filter)
        {     
            var routes = _routeService.List(filter).ToList();

            var output = AutoMapper.Mapper.Map<List<Route>, List<ListRouteModel>>(routes);

            return output;
        }


        [HttpPost]
        public Route Add(CreateRouteModel model)
        {
            return _routeService.CreateRoute(model);
        }  

       [HttpGet]
       public ListRouteModel Get(int id)
       {
            var route =  _routeService.Get(id);
            var output = AutoMapper.Mapper.Map<Route, ListRouteModel>(route);
            return output;
        }

        [HttpPut]
        public RouteModel Update(UpdateRouteModel model)
        {
            var route = _routeService.UpdateRoute(model);
            var output = AutoMapper.Mapper.Map<Route, RouteModel>(route);
            return output;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _routeService.Delete(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Together.BL.DTOModels;
using Together.BL.DTOModels.Route;
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
        public IEnumerable<ListRouteModel> Get()
        {
            Stopwatch sw = Stopwatch.StartNew();
           

            var routes = _routeService.GetAll().ToList();
            var t1 = sw.ElapsedTicks;
            var output = AutoMapper.Mapper.Map<List<Route>, List<ListRouteModel>>(routes);
            var t2 = sw.ElapsedTicks;
            sw.Stop();
            Debug.WriteLine($"{t1}\t{t2-t1}");
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
            var route =  _routeService.GetById(id);
            var output = AutoMapper.Mapper.Map<Route, ListRouteModel>(route);
            return output;
        }

        [HttpPut]
        public void Update(UpdateRouteModel model)
        {
            _routeService.UpdateRoute(model);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _routeService.Delete(id);
        }
    }
}

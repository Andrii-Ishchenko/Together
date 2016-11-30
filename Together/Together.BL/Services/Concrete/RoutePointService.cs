using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL.DTOModels;
using Together.BL.Services.Abstract;
using Together.DAL.Repository.Abstract;
using Together.Domain.Entities;

namespace Together.BL.Services.Concrete
{
    public class RoutePointService : BaseService<RoutePoint>, IRoutePointService
    {
        private readonly IRouteService _routeService;

        public RoutePointService(IRouteService routeService, IBaseRepository<RoutePoint> repository) : base(repository)
        {
            _routeService = routeService;
        }

        public void AddPointToRoute(AddPointToRouteModel routePointModel)
        {
            
        }
    }
}

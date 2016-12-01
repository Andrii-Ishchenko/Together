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

        public void AddPointToRoute(AddPointToRouteModel model)
        {
            if (model.RouteId < 0)
                throw new Exception($"Wrong route ID: {model.RouteId}");

            var route = _routeService.GetById(model.RouteId);

            if (route == null)
                throw new Exception("Cannot find specified route");

            //CHECK SECURITY: YOU CAN ADD POINTS TO ROUTES where you are owner or passenger.

            //Get USER BY ID FROM SESSION(?)

            //SELECT ROUTE POINTS AND SET LIST ORDER;

            RoutePoint rp = new RoutePoint()
            {
                RouteId = route.Id,
                Address = model.Address,
                ConfirmDate = null,
                IsConfirmed = false,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                SuggestDate = DateTime.Now,
                SuggestUserId = 1,
                ListOrder = model.PointOrder

            };

            _repository.Add(rp);
            _repository.SaveChanges();


        }
    }
}

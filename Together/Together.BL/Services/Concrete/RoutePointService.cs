using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL.DTO;
using Together.BL.Services.Abstract;
using Together.DAL.Infrastructure;
using Together.DAL.Repository.Abstract;
using Together.Domain;

namespace Together.BL.Services.Concrete
{
    public class RoutePointService : BaseService<RoutePoint>, IRoutePointService
    {
        private readonly IRouteService _routeService;
        private readonly IAppUserService _userService;
        public RoutePointService(IRouteService routeService, IAppUserService userService, IUnitOfWorkFactory factory) : base(factory)
        {
            _routeService = routeService;
            _userService = userService;
        }

        public void AddPointToRoute(CreateRoutePointModel model)
        {
            if (model.RouteId < 0)
                throw new Exception($"Wrong route ID: {model.RouteId}");

            using (IUnitOfWork uow = factory.Create())
            {
                var route = _routeService.GetById(model.RouteId);

                if (route == null)
                    throw new Exception("Cannot find specified route");

                //TODO: USE ID FROM AUTH
                var user = _userService.GetById(1);
                if (user == null)
                    throw new Exception("Cannot find specified user");

                //CHECK SECURITY: YOU CAN ADD POINTS TO ROUTES only when you are owner or passenger.

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
                    SuggestUser = user,
                    ListOrder = model.PointOrder
                };

                var repository = uow.Repository<RoutePoint>();
                repository.Add(rp);
                uow.Save();
            }

         


        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DataAccess;
using Together.Services.Interfaces;
using Together.Services.Models;
using Together.Services.Requests;
using Together.Services.Exceptions;
using Together.Domain.Entities;

namespace Together.Services
{
    public class RouteService : IRouteService
    {
        private readonly TogetherDbContextFactory _factory;
        private readonly IUserService _userService;

        public RouteService(TogetherDbContextFactory factory, IUserService userService)
        {
            _factory = factory;
            _userService = userService;       
        }

        public List<RouteListModel> List()
        {
            using (TogetherDbContext db = _factory.Create())
            {
                var list = db.Routes.Include(r => r.Passengers.Select(p => p.User))
                    .Include(r => r.RoutePoints.Select(rp => rp.Creator))
                    .ToList();
                return AutoMapper.Mapper.Map<List<RouteListModel>>(list);
            }
        }

        public bool RouteExists(int id)
        {
            using (TogetherDbContext db = _factory.Create())
            {
                return db.Routes.Any(r => r.Id == id);
            }
        }
    }
}

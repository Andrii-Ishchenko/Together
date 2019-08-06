using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DataAccess;
using Together.Services.Models;

namespace Together.Services
{
    public class RouteService : IRouteService
    {
        private readonly TogetherDbContextFactory _factory;

        public RouteService(TogetherDbContextFactory factory)
        {
            _factory = factory;
        }

        public List<RouteListModel> List()
        {
            using (TogetherDbContext db = _factory.Create())
            {
                var list =  db.Routes.Include(r => r.Passengers.Select(p=>p.User))
                    .Include(r=>r.RoutePoints.Select(rp=>rp.Creator))
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

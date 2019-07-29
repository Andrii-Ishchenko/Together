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
            using (TogetherDbContext db = _factory.CreateDbContext())
            {
                var list =  db.Routes.Include(r => r.Passengers).ToList();
                return AutoMapper.Mapper.Map<List<RouteListModel>>(list);
            }
        }
    }
}

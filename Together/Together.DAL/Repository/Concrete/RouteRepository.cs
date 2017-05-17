using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Infrastructure;
using Together.DAL.Repository.Abstract;
using Together.DAL.Utils;
using Together.Domain;

namespace Together.DAL.Repository.Concrete
{
    public class RouteRepository : BaseRepository<Route>, IRouteRepository
    {
        public RouteRepository(TogetherDbContext context) : base(context)
        {
        }

        public override IEnumerable<Route> List(Filter filter)
        {
            return Query(null, filter, new[] {"RoutePoints", "RouteUsers", "Owner"}).ToList();
        }
    }
}

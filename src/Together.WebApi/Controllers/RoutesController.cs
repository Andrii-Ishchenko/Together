using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Together.DataAccess;

namespace Together.WebApi.Controllers
{
    public class RoutesController : ApiController
    {
        
        private async Task<IHttpActionResult> GetRoutesNotWorkingAsync()
        {
            using(TogetherDbContext db = new TogetherDbContext())
            {
                var list = await db.Routes.SelectMany(r => r.Passengers).ToListAsync();
                return Ok(list);
            }
        }

        public IHttpActionResult GetRoutes()
        {
            //!!!! using (TogetherDbContext db = new TogetherDbContext())
            TogetherDbContext db = new TogetherDbContext();
            var list = db.Routes.Include(r => r.Passengers.Select(p=>p.User)).ToList();

            return Ok(list);
            
        }
    }
}

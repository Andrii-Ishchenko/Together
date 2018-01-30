using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Together.Data.Domain;
using Together.Data.Context;
using Together.Services.Route.DTO;


namespace Together.Services.Route
{
    public class RouteCRUDService : IRouteCRUDService
    {
        private TogetherDbContext context;

        public RouteCRUDService(TogetherDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<RouteListDTO> GetAll()
        {

            return this.context
                .Set<Data.Domain.Route>()
                .Include(x=>x.RoutePoints)    
                .Select(x => new RouteListDTO()
                {
                    Id = x.Id,
                    CreateDate = x.CreateDate,
                    RouteType = x.RouteType,
                    NumberOfPoints = x.RoutePoints.Count()
                }).ToList();
        } 

    }
}

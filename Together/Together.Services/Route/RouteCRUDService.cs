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
using Together.Services.RoutePoint.DTO;

namespace Together.Services.Route
{
    public class RouteCRUDService : IRouteCRUDService
    {
        private TogetherDbContext context;

        public RouteCRUDService(TogetherDbContext context)
        {
            this.context = context;
        }

        public List<RouteListDTO> GetAll()
        {

            return this.context
                .Routes
                .AsNoTracking()
                .Include(x=>x.RoutePoints)    
                .Select(x => new RouteListDTO()
                {
                    Id = x.Id,
                    CreateDate = x.CreateDate,
                    RouteType = x.RouteType,
                    NumberOfPoints = x.RoutePoints.Count()
                }).ToList();
        } 

        public RouteDTO Get(int id)
        {
            var route = context.Routes
                .AsNoTracking()
                .Include(r => r.RoutePoints)
                .SingleOrDefault(r => r.Id == id);

            return (route == null)
                    ? null
                    : new RouteDTO()
                    {
                        Id = route.Id,
                        CreateDate = route.CreateDate,
                        RouteType = route.RouteType,
                        RoutePoints = route.RoutePoints
                        .Select(p => new RoutePointDTO()
                        {
                            Address = p.Address,
                            Id = p.Id,
                            Latitude = p.Latitude,
                            Longitude = p.Longitude
                        })
                        .ToList()
                    };
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL.Services.Abstract;
using Together.DAL.Infrastructure.Abstract;
using Together.DAL.Repository.Abstract;
using Together.Domain.Entities;

namespace Together.BL.Services.Concrete
{
    public class RouteService : BaseService<Route>, IRouteService
    {
        public RouteService(IRouteRepository repository, IUnitOfWorkFactory factory): base(repository, factory)
        {
                
        }

        
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL.DTO;
using Together.Domain;


namespace Together.BL.Services.Abstract
{
    public interface IRoutePointService : IBaseService<RoutePoint>
    {
        void AddPointToRoute(CreateRoutePointModel model);
    }
}

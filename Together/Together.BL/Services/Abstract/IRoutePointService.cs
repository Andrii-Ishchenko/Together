using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL.DTOModels;
using Together.Domain.Entities;

namespace Together.BL.Services.Abstract
{
    public interface IRoutePointService : IBaseService<RoutePoint>
    {

        void AddPointToRoute(AddPointToRouteModel model);
    }
}

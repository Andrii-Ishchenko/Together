using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Together.BL.DTOModels.Route;
using Together.DAL.Entities;

namespace Together.BL.Services.Abstract
{
    public interface IRouteService : IBaseService<Route>
    {

        Route CreateRoute(CreateRouteModel model);

        Route UpdateRoute(UpdateRouteModel model);
    }
}

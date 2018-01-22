using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Together.BL.DTO;
using Together.Domain;

namespace Together.BL.Services
{
    public interface IRouteService : ICRUDService<Route>
    {
        Route CreateRoute(CreateRouteModel model);

        Route UpdateRoute(UpdateRouteModel model);
    }
}

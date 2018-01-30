using System.Collections.Generic;
using System.Linq;
using Together.Services.Route.DTO;

namespace Together.Services.Route
{
    public interface IRouteCRUDService
    {

        IEnumerable<RouteListDTO> GetAll();

    }
}
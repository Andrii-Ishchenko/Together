using System.Collections.Generic;
using Together.Services.Models;

namespace Together.Services
{
    public interface IRouteService
    {
        List<RouteListModel> List();
    }
}
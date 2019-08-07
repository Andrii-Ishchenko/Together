using System.Collections.Generic;
using Together.Services.Models;
using Together.Services.Requests;

namespace Together.Services.Interfaces
{
    public interface IRouteService
    {
        List<RouteListModel> List();

        bool RouteExists(int id);

    }
}
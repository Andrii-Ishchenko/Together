using Together.Services.Models;
using Together.Services.Requests;

namespace Together.Services.Interfaces
{
    public interface IRoutePointService
    {
        NewRoutePointModel AddPointToRoute(CreateRoutePointRequest request);
    }
}
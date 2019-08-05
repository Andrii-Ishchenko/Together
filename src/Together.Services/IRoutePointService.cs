using Together.Services.Models;
using Together.Services.Requests;

namespace Together.Services
{
    public interface IRoutePointService
    {
        NewRoutePointModel AddPointToRoute(CreateRoutePointRequest request);
    }
}
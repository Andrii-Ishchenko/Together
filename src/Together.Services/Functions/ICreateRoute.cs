using Together.Services.Models;
using Together.Services.Requests;

namespace Together.Services.Functions
{
    public interface ICreateRoute
    {
       NewRouteModel Create(string userId, CreateRouteRequest request);
    }
}
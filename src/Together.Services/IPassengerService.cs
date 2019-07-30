using Together.Domain.Entities;
using Together.Services.Models;

namespace Together.Services
{
    public interface IPassengerService
    {
        NewPassengerModel AddUserToRoute(int userId, int routeId);

        void RemoveUserFromRoute(int userId, int routeId);
    }
}
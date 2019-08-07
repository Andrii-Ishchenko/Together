using Together.Domain.Entities;
using Together.Services.Models;

namespace Together.Services.Interfaces
{
    public interface IPassengerService
    {
        NewPassengerModel AddUserToRoute(int userId, int routeId);

        void DeletePassenger(int passengerId);
    }
}
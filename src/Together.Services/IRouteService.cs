using System.Threading.Tasks;
using Together.Domain.Entities;
using Together.Services.Requests;

namespace Together.Services
{
    public interface IRouteService
    {
        Task<Passenger> AddPassenger(CreatePassengerRequest model);
    }
}
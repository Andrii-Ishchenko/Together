using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Services.Exceptions
{
    public class PassengerAlreadyExistsException : Exception
    {
        private readonly string _userId;
        private readonly int _routeId;

        public PassengerAlreadyExistsException(string userId, int routeId)
        {
            _userId = userId;
            _routeId = routeId;
        }

        public override string ToString()
        {
            return $"User({_userId}) is already a passenger of Route({_routeId})";
        }
    }
}

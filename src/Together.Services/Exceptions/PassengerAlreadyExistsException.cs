using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Services.Exceptions
{
    public class PassengerAlreadyExistsException : BusinessException
    {
        public PassengerAlreadyExistsException(string userId, int routeId) 
            : base ($"User({userId}) is already a passenger of Route({routeId})")
        {
        }
    }
}

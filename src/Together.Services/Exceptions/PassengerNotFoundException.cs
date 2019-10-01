using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Together.Services.Exceptions
{
    public class PassengerNotFoundException : BusinessException     
    {
        public PassengerNotFoundException(int passengerId)
            : base ($"Passenger {passengerId} not found.", HttpStatusCode.NotFound)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Together.Services.Requests
{
    public class CreatePassengerRequest
    {
        public int RouteId { get; set; 
        }
        public string UserId { get; set; }

    }
}

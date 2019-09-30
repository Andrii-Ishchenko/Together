using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Services.Requests
{
    public class CreatePassengerRequest
    {
        public string UserId { get; set; }
        public int RouteId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Services.Requests
{
    public class CreateRouteRequest
    {

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public int MaxPassengers { get; set; }

        public string RouteType { get; set; }

        public bool IsPrivate { get; set; }
    }
}

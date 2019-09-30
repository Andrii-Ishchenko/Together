using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Services.Requests
{
    public class CreateRoutePointRequest
    {
        public string UserId { get; set; }

        public int RouteId { get; set; }

        public string Name { get; set; }

        public int OrderNumber { get; set; }

        public float Longitude { get; set; }

        public float Latitude { get; set; }
    }
}

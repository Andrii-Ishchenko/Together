using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.BL.DTO
{
    public class CreateRouteModel
    {
        public int MaxPassengers { get; set; }

        public string RouteType { get; set; }

        public bool? IsPrivate { get; set; }

        public string SecretKey { get; set; }

        public DateTime StartDate { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.BL.DTOModels.Route
{
    public class UpdateRouteModel
    {
        public int Id { get; set; }

        public int? MaxPassengers { get; set; }

        public string RouteType { get; set; }

        public bool? IsPrivate { get; set; }

        public string SecretKey { get; set; }

        public DateTime? StartDate { get; set; }

    }
}

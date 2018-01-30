using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.Services.RoutePoint.DTO;

namespace Together.Services.Route.DTO
{
    public class RouteDTO
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string RouteType { get; set; }

        public List<RoutePointDTO> RoutePoints { get; set; }
    }
}

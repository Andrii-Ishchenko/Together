using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Data.Domain
{
    public class Route
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set;}

        public string RouteType { get; set; }

        public virtual ICollection<RoutePoint> RoutePoints { get; set; }

        public Route()
        {
            RoutePoints = new List<RoutePoint>();
        }
    }
}

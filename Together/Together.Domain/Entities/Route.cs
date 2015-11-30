using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Domain.Entities
{
    public class Route
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public string RouteType { get; set; }
        
        public bool IsPrivate { get; set; }

        public bool IsLocked { get; set; }

        public int? GroupId { get; set; }

        public virtual List<RoutePoint> RoutePoints { get; set; }

		//public virtual List<Point> Points { get; set; }

		public virtual List<RouteUser> RouteUsers { get; set; }

        public virtual Group Group { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Together.Domain.Entities
{
    public class Route
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CreateDate { get; set; }

        public int MaxPassengers { get; set; }

        public string RouteType { get; set; }

        public bool IsPrivate { get; set; }

        public virtual ICollection<Passenger> Passengers { get;set; }
    }
}

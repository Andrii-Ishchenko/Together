using System;
using System.Collections.Generic;
using System.Text;

namespace Together.Domain.Entities
{
    public class Passenger
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public virtual Route Route { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime JoinDate { get; set; }
        
    }
}

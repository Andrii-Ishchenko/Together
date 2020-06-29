using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Together.Domain.Entities
{
    public class UserProfile
    {
        [ForeignKey("UserAccount")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual List<Passenger> Passengers { get; set; }

        public virtual List<RoutePoint> CreatedRoutePoints { get; set; }

        public virtual List<Route> CreatedRoutes { get; set; }

        public virtual UserAccount UserAccount { get; set; }
    }
}

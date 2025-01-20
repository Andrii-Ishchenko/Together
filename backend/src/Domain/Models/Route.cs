using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public class Route
{
    public int Id { get; set; }

    public int OwnerId { get; set; }

    public int TransportId { get; set; }

    public User Owner { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public IEnumerable<RoutePoint> RoutePoints { get; set; }
    public IEnumerable<RouteUser> Passengers { get; set; }
}

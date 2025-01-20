using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;
public class RouteUser
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public int RouteId { get; set; }

    public DateTimeOffset JoinDate { get; set; }

    public virtual User User { get; set; }
    public virtual Route Route { get; set; }
}

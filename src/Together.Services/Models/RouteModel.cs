using System;
using System.Collections.Generic;

namespace Together.Services.Models
{
    public class RouteModel
    {
        public int Id { get; set; }

        public string CreatorId { get; set; }

        public string CreatorFirstName { get; set; }

        public string CreatorLastName { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CreateDate { get; set; }

        public int MaxPassengers { get; set; }

        public string RouteType { get; set; }

        public bool IsPrivate { get; set; }

        public List<RoutePointModel> RoutePoints { get; set; }

        public List<PassengerModel> Passengers { get; set; }
    }
}

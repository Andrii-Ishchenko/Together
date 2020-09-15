using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Together.WebApi.ViewModels
{
    public class RouteViewModel
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

        public List<RoutePointViewModel> RoutePoints { get; set; }

        public List<PassengerViewModel> Passengers { get; set; }
    }
}

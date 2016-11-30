using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Together.WebApi.Models
{
    public class ListRouteModel
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public int Passengers { get; set; }

        public int MaxPassengers { get; set; }

        public string RouteType { get; set; }

        public bool IsPrivate { get; set; }   
      
        public  UserListModel Owner { get; set; }

        public RoutePointListModel StartPoint { get; set; }

        public RoutePointListModel EndPoint { get; set; }
    }
}
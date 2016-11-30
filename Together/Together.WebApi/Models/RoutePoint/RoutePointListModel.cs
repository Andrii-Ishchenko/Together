using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Together.WebApi.Models
{
    public class RoutePointListModel
    {
        public int Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Adress { get; set; }
    }
}
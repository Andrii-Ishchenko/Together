using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Together.BL.DTOModels
{
    public class CreateRoutePointModel
    {
        public int RouteId { get; set; }
        
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Address { get; set; }

        public int PointOrder { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Services.Route.DTO
{
    public class RouteListDTO
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string RouteType { get; set; }

        public int NumberOfPoints { get; set; }
    }
}

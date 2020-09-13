using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Together.WebApi.ViewModels
{
    public class CreateRouteViewModel
    {
        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public string RouteType { get; set; }

        public int MaxPassengers { get; set; }

        public bool IsPrivate { get; set; }
    }
}

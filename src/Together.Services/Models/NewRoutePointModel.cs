using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Services.Models
{
    public class NewRoutePointModel
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public string CreatorId { get; set; }

        public string Name { get; set; }

        public int OrderNumber { get; set; }

        public float Longitude { get; set; }

        public float Latitude { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatorFirstName { get; set; }

        public string CreatorLastName { get; set; }

    }
}

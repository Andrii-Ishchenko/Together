using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Services.Models
{
    public class NewPassengerModel
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public string UserId { get; set; }

        public DateTime JoinDate { get; set; }
    }
}

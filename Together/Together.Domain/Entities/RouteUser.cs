using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Domain.Entities
{
    public class RouteUser
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public int UserId { get; set; }

        public DateTime JoinDate { get; set; }

        
    }
}

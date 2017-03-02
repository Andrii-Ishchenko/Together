using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.Domain.Identity;

namespace Together.Domain
{
    public class RouteUser
    {
        [Key, Column(Order = 0)]
        public int RouteId { get; set; }

        [Key, Column(Order = 1)]
        public int UserId { get; set; }

        public DateTime JoinDate { get; set; }
		
        [ForeignKey("RouteId")]
        public virtual Route Route { get; set; }

        [ForeignKey("UserId")]
		public virtual AppUser User { get; set; }
    }
}

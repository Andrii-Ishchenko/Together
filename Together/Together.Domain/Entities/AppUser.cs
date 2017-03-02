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
	public class AppUser
    {
        [Key]
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public virtual List<RouteUser> UserRoutes {get;set;}

		public virtual List<GroupUser> GroupUser { get; set; }

		public virtual List<RoutePoint> RoutePoints { get; set; }

        public virtual User User { get; set; }
    }
}

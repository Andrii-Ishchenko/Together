using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Domain.Entities
{
	public class User
	{
        [Key]
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public virtual List<RouteUser> UserRoutes {get;set;}

		public virtual List<GroupUser> GroupUser { get; set; }

		public virtual List<RoutePoint> RoutePoints { get; set; }

	}
}

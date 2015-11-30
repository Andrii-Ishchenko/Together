using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Infrastructure.Concrete;
using Together.Domain.Entities;

namespace Together.Sandbox
{
	class Program
	{
		static void Main(string[] args)
		{
			using (TogetherDbContext db = new TogetherDbContext())
			{
				User u = new User() { FirstName = "A", LastName = "B", Id = 123 };
				db.Users.Add(u);
				db.SaveChanges();

			}
		}
	}
}

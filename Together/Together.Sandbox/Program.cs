using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Infrastructure.Concrete;
using Together.DAL.Repository.Concrete;
using Together.Domain.Entities;

namespace Together.Sandbox
{
	class Program
	{
		static void Main(string[] args)
		{
			BaseRepository<Point> rep = new BaseRepository<Point>(new TogetherDbContext());

			Point p = new Point() { Latitude = 0.123, Longitude = 0.456 };
			
			rep.Add(p);

			rep.SaveChanges();

			BaseRepository<User> urep = new BaseRepository<User>(new TogetherDbContext());

			User u = new User() { FirstName = "A", LastName = "B" };

			urep.Add(u);

			urep.SaveChanges();

        }
	}
}

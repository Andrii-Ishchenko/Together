﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Infrastructure;

namespace Together.Sandbox
{
	class Program
	{
		static Program()
		{			
			
		}

		static void Main(string[] args)
		{



            using (var context = new TogetherDbContext())
            {

                var users = context.AppUsers.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine("{0}\t{1}\t{2}",user.Id, user.FirstName, user.LastName);
                }

                var routeOwnerUser = users.FirstOrDefault(u => u.FirstName == "John");

                var route = context.Routes.FirstOrDefault(r => r.OwnerId == routeOwnerUser.Id);

                Console.WriteLine("{0}\t{1}\t{2}\t{3}", route.Id, route.OwnerId, route.Owner.FirstName, route.Owner.LastName);
            }


            Console.ReadKey();
        }
	}
}

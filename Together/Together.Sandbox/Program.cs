using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL;
using Together.BL.Services.Concrete;
using Together.DAL.Infrastructure.Concrete;

namespace Together.Sandbox
{
	class Program
	{
		static Program()
		{			
			
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Main");
			Console.ReadKey();

            using (var context = new TogetherDbContext())
            {

                var list = context.Points.ToList();
                list.ForEach(Console.WriteLine);
            }
            
        }
	}
}

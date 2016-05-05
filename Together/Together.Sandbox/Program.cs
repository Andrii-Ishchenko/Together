using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL;

namespace Together.Sandbox
{
	class Program
	{
		static Program()
		{			
			AutoMapperConfig.Configure();
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Main");
			Console.ReadKey();
        }
	}
}

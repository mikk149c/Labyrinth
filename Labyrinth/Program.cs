using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
	class Program
	{
		static void Main(string[] args)
		{
			Cord size = new Cord(26, 26);
			Cord start = new Cord(0, 0);
			Cord end = new Cord(25, 25);
			Labyrinth lab = new Labyrinth(size, start, end);
			Console.ReadKey();
		}
	}
}

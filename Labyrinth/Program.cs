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
			Labyrinth lab = new Labyrinth(11, 11);
			lab.Start = new Cord(0, 0);
			lab.End = new Cord(10, 7);
			lab.GenaratePath();
			lab.ToString();
			Console.ReadKey();
		}
	}
}

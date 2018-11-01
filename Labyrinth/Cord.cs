using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
	public class Cord
	{
		private int x;
		private int y;

		public Cord(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get { return x; } set { x = value; } }
		public int Y { get { return y; } set { y = value; } }
		
	}
}

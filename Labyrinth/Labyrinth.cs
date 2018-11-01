using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathFinding;

namespace Labyrinth
{
	public class Labyrinth : INavigable
	{
		private Cord start;
		private Cord end;
		private Cord size;
		private Cell[,] cells;
		public Cord Start { get { return start; } set { start = value; } }
		public Cord End { get { return end; } set { end = value; } }
		public Cord Size { get { return size; } set { size = value; } }
		public Cell[,] Cells { get { return cells; } set { cells = value; } }

		public Labyrinth(int x, int y)
		{
			Size.X = x;
			Size.Y = y;
			Cells = new Cell[x, y];
		}

		internal List<INode> GetNaibors(Cell cell)
		{
			List<Cell> naibors = new List<Cell>();
			naibors.Add();
			naibors.Add();
			naibors.Add();
			naibors.Add();
		}

		internal void GenaratePath()
		{
			GenaratePath(Start);
		}

		internal void GenaratePath(Cord cord)
		{
			
		}

		public INode GetFirstNode()
		{
			return start;
		}

		public INode GetLastNode()
		{
			throw new NotImplementedException();
		}
	}
}
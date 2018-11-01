using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathFinding;

namespace Labyrinth
{
	public class Cell : INode
	{
		private bool isPath = false;
		private bool isWall = false;
		private Cord pos;
		private Labyrinth parent;

		public Cell(Labyrinth parent, Cord pos)
		{
			this.parent = parent;
			Pos = pos;
		}

		public bool IsPath { get { return isPath; } set { isPath = value; } }
		public bool IsWall { get { return isWall; } set { isWall = value; } }
		public Cord Pos { get { return pos; } set { pos = value; } }

		public List<INode> GetNaibors(INode node)
		{
			return parent.GetNaibors(this);
		}
	}
}

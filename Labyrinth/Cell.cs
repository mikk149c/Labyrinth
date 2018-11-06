using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathFinding;

namespace Labyrinth
{
	public class Cell : INode, ICloneable
	{
		private bool isPath = false;
		private Cord pos;
		private Labyrinth parent;

		public Cell(Labyrinth parent, Cord pos)
		{
			this.parent = parent;
			Pos = pos;
		}

		public bool IsPath { get { return isPath; } set { isPath = value; } }
		public Cord Pos { get { return pos; } set { pos = value; } }
		public bool CanCompleat { get { return PathFinding.PathFinding.CanCompleat(parent, this); } }
		public Labyrinth Parent { set { parent = value; } }

		public List<INode> GetNaibors()
		{
			List<INode> list = new List<INode>();
			foreach (Cell c in GetValidNaibors())
				list.Add(c);
			return list;
		}

		internal List<Cell> GetValidNaibors()
		{
			return parent.GetValidNaibors(this);
		}

		public bool IsWall()
		{
			foreach (Cell c in parent.GetNaibors(this))
				if (c.isPath)
					return true;
			return false;
		}

		public bool Equals(INode node)
		{
			if (node is Cell c)
				return this.Pos.Equals(c.Pos);
			return false;
		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}

		internal bool Same(Cell other)
		{
			return IsWall() == other.IsWall() && isPath == other.isPath;
		}
	}
}

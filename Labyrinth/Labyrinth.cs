using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathFinding;

namespace Labyrinth
{
	public class Labyrinth : INavigable, ICloneable
	{
		private Cord start;
		private Cord end;
		private Cord size;
		private Cell[,] cells;
		private Labyrinth currentShowingBoard;
		public Cord Start { get { return start; } set { start = value; } }

		public Cord End { get { return end; } set { end = value; } }
		public Cord Size { get { return size; } set { size = value; } }

		public Labyrinth(int x, int y)
		{
			Size = new Cord(x, y);
			cells = new Cell[Size.X, Size.Y];
			for (int i = 0; i < Size.X; i++)
				for (int j = 0; j < Size.Y; j++)
					SetCell(new Cell(this, new Cord(i, j)));
		}

		public Labyrinth(Cord sizei, Cord start, Cord end) : this(sizei.X, sizei.Y)
		{
			Start = start;
			End = end;
			for (int i = 0; i < cells.GetLength(0); i++)
			{
				Console.BackgroundColor = ConsoleColor.Black;
				Console.WriteLine(" ");
			}
			GenaratePath();
		}

		public Labyrinth()
		{
		}

		internal List<Cell> GetValidNaibors(Cell cell)
		{
			List<Cell> naibors = GetNaibors(cell);
			List<Cell> validNaibors = new List<Cell>();
			foreach (Cell c in naibors)
					if (!c.IsWall() && !c.IsPath)
						validNaibors.Add(c);
			return validNaibors;
		}

		internal List<Cell> GetNaibors(Cell cell)
		{
			List<Cell> naibors = new List<Cell>();
			naibors.Add(GetCell(cell.Pos.X - 1, cell.Pos.Y));
			naibors.Add(GetCell(cell.Pos.X, cell.Pos.Y - 1));
			naibors.Add(GetCell(cell.Pos.X + 1, cell.Pos.Y));
			naibors.Add(GetCell(cell.Pos.X, cell.Pos.Y + 1));
			List<Cell> validNaibors = new List<Cell>();
			foreach (Cell c in naibors)
				if (c != null)
					validNaibors.Add(c);
			return validNaibors;
		}

		public Cell GetCell(int x, int y)
		{
			if (0 <= x && x < Size.X && 0 <= y && y < Size.Y)
				return cells[x, y];
			return null;
		}

		public INode GetNode(int x, int y)
		{
			return GetCell(x, y);
		}

		public Cell GetCell(Cord pos)
		{
			return GetCell(pos.X, pos.Y);
		}

		private void SetCell (Cell cell)
		{
			cells[cell.Pos.X, cell.Pos.Y] = cell;
		}
		int i = 0;
		private void GenaratePath(Cell cell)
		{
			Random r = new Random();
			List<Cell> naibors = cell.GetValidNaibors();
			List<Cell> validNaibors = new List<Cell>();
			foreach (Cell c in naibors)
			{
				if (c.Equals(GetCell(end)))
				{
					cell.IsPath = true;
					c.IsPath = true;
					Display();
					return;
				}
			}
			cell.IsPath = true;
			int ra = r.Next(naibors.Count);
			while (!naibors[ra].CanCompleat)
			{
				naibors.RemoveAt(ra);
				ra = r.Next(naibors.Count);
			}
			Cell nextCell = naibors[ra];
			Console.WriteLine(i++);
			if (i % 1 == 0)
				Display();
			//System.Threading.Thread.Sleep(1000/12);
			GenaratePath(nextCell);
		}

		internal void GenaratePath()
		{
			GenaratePath(GetCell(Start));
		}

		public INode GetFirstNode()
		{
			return GetCell(start);
		}

		public INode GetLastNode()
		{
			return GetCell(End);
		}

		public void Display()
		{
			Console.BackgroundColor = ConsoleColor.Black;
			//Console.Clear();
			Console.Write("  ");
			Console.SetCursorPosition(2,0);
			for (int i = 0; i < Size.Y; i++)
			{
				Console.Write((char)(i+(int)'A') + " ");
			}
			Console.Write("\n");
			for (int x = 0; x < Size.X; x++)
			{
				Console.SetCursorPosition(0, x+1);
				Console.Write((char)(x + (int)'A') + " ");
				for (int y = 0; y < Size.Y; y++)
				{
					if (currentShowingBoard != null)
						if (!currentShowingBoard.cells[x, y].Same(cells[x, y]))
						{
							Console.SetCursorPosition(y * 2 + 2, x + 1);
							if (GetCell(x, y).IsPath)
							{
								Console.BackgroundColor = ConsoleColor.Yellow;
							}
							else if (GetCell(x, y).IsWall())
							{
								Console.BackgroundColor = ConsoleColor.Black;
							}
							else if (new Cord(x, y).Equals(start) || new Cord(x, y).Equals(end))
							{
								Console.BackgroundColor = ConsoleColor.Blue;
							}
							else
							{
								Console.BackgroundColor = ConsoleColor.Gray;
							}
							Console.Write("  ");
						}
				}
				Console.WriteLine();
				Console.BackgroundColor = ConsoleColor.Black;
			}
			currentShowingBoard = (Labyrinth)this.Clone();
			
		}

		public object Clone()
		{
			Labyrinth labyrinth = (Labyrinth)this.MemberwiseClone();
			labyrinth.cells = new Cell[cells.GetLength(0), cells.GetLength(1)];
			for (int x = 0; x < cells.GetLength(0); x++)
				for (int y = 0; y < cells.GetLength(1); y++)
				{
					labyrinth.cells[x, y] = (Cell)cells[x, y].Clone();
					labyrinth.cells[x, y].Parent = labyrinth;
				}
			return labyrinth as object;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Text;

namespace PathFinding
{
	class DigstraNode
	{
		public INode Node;
		public int Lenght;
		public DigstraNode LastNode;

		public DigstraNode(INode node, int lenght, DigstraNode lastNode)
		{
			Node = node;
			Lenght = lenght;
			LastNode = lastNode;
		}
	}
}

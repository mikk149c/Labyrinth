using System;
using System.Collections.Generic;
using System.Text;

namespace PathFinding
{
	public interface INavigable
	{
		INode GetFirstNode();
		INode GetLastNode();
		INode GetNode(int x, int Y);
	}
}

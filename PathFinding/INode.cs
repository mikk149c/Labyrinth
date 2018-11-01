using System;
using System.Collections.Generic;
using System.Text;

namespace PathFinding
{
	public interface INode
	{
		List<INode> GetNaibors(INode node);


	}
}

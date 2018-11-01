using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinding
{
	public static class PathFinding
	{
		public static List<INode> FindPath(INavigable navigable)
		{
			return FindPath(navigable, navigable.GetFirstNode());
		}

		private static List<INode> FindPath(INavigable navigable, INode start)
		{
			List<DigstraNode> checkedNodes = new List<DigstraNode>();
			List<DigstraNode> nodesToChecke = new List<DigstraNode>();
			DigstraNode curretnNode = new DigstraNode(start, 0, null);
			INode lastNode = navigable.GetLastNode();
			do
			{
				List<INode> tempList = curretnNode.Node.GetNaibors();
				foreach (INode n in tempList)
					if (!checkedNodes.Exists(x => x.Node.Equals(n)))
						nodesToChecke.Add(new DigstraNode(n, curretnNode.Lenght + 1, curretnNode));
				if (nodesToChecke.Count.Equals(0))
					return null;
				nodesToChecke.OrderBy(x => x.Lenght);
				checkedNodes.Add(curretnNode);
				curretnNode = nodesToChecke[0];
				nodesToChecke.RemoveAll(x => x.Node.Equals(curretnNode.Node));
			} while (!curretnNode.Node.Equals(lastNode));

			List<INode> reversPath = new List<INode>();
			do
			{
				reversPath.Add(curretnNode.Node);
				curretnNode = curretnNode.LastNode;
			} while (curretnNode.LastNode != null);

			List<INode> path = new List<INode>();
			for (int i = reversPath.Count-1; i >= 0; i--)
				path.Add(reversPath[i]);
			return path;
		}

		public static bool CanCompleat(INavigable navigable, INode start)
		{
			if (FindPath(navigable, start) != null)
				return true;
			return false;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
			nodesToChecke.Add(curretnNode);
			INode lastNode = navigable.GetLastNode();
			bool exit = false;
			DigstraNode exitNode = curretnNode;
			do
			{
				if (nodesToChecke.Count.Equals(0))
					return null;

				nodesToChecke.OrderBy(x => x.Lenght);
				List<Task<List<DigstraNode>>> tasks = new List<Task<List<DigstraNode>>>();
				foreach (DigstraNode node in nodesToChecke.ToList())
				{
					tasks.Add(Task<List<DigstraNode>>.Run(() =>
					{
						List<INode> tempList = node.Node.GetNaibors();
						List<DigstraNode> dList = new List<DigstraNode>();
						foreach (INode n in tempList)
							try
							{
								if (!checkedNodes.Exists(x => x.Node.Equals(n)))
								{
									DigstraNode d = new DigstraNode(n, node.Lenght + 1, node);
									dList.Add(d);
								}
							}
							catch (NullReferenceException)
							{
								
							}
						return dList;
					}));
					if (node.Node.Equals(lastNode))
					{
						exit = true;
						exitNode = node;
					}
					if (node != null)
						checkedNodes.Add(node);
				}
				var l = Task.WhenAll(tasks).Result;
				foreach (List<DigstraNode> td in l)
					foreach (DigstraNode d in td)
						if (d != null && !nodesToChecke.Exists(x => x.Equals(d)))
							nodesToChecke.Add(d);

				nodesToChecke = nodesToChecke.Distinct().ToList();
				nodesToChecke = nodesToChecke.Except(checkedNodes).ToList();
			} while (exit == false);

			List<INode> reversPath = new List<INode>();
			do
			{
				reversPath.Add(exitNode.Node);
				exitNode = exitNode.LastNode;
			} while (exitNode.LastNode != null);

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
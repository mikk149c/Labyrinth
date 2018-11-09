using System;
using System.Collections.Generic;

namespace ConsoleWriter
{
	public class Frame
	{
		private List<List<ConsoleField>> consoleFields = new List<List<ConsoleField>>();
		ConsoleField selection;
		public ConsoleField Selection { get { return selection; } set { selection = value; } }

		public void Select(int x, int y)
		{
			for (int i = consoleFields.Count; i < x+1; i++)
				consoleFields.Add(new List<ConsoleField>());
			for (int i = consoleFields[x].Count; i <= y+1; i++)
				consoleFields[x].Add(new ConsoleField());
			selection = consoleFields[x][y];
		}
	}
}
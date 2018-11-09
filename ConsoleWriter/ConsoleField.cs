using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleWriter
{
	public class ConsoleField
	{
		private char character = ' ';
		private ConsoleColor forgroundColor = ConsoleColor.White;
		private ConsoleColor backgroundColor = ConsoleColor.Black;
		public char Character { get { return character; } set { character = value; } }
		public ConsoleColor ForgoundColor { get { return forgroundColor; } set { forgroundColor = value; } }
		public ConsoleColor BackgoundColor { get { return backgroundColor; } set { backgroundColor = value; } }
	}
}
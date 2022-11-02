using System;
using System.Collections.Generic;
using System.Text;

namespace RectanglesCommands
{
	public class Position
	{
		public int X { get; private set; }
		public int Y { get; private set; }

		public static Position ParsePositionParameters(String parameters)
		{
			Position position = new Position();
			string[] paramArray = parameters.Split(',');

			if (paramArray.Length < 2)
			{
				//Console.WriteLine("Invalid command parameters. Position coordinates must be specified");
				throw new ArgumentException("Invalid command parameters. Position coordinates must be specified");
			}

			position.X = int.Parse(paramArray[0]);
			position.Y = int.Parse(paramArray[1]);

			return position;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RectanglesCommands
{
	public class Rectangles
	{
		private List<int> X;
		private List<int> Y;

		public Rectangles()
		{
			X = new List<int>();
			Y = new List<int>();
		}
		public void ExecuteCommand(string command, string parameters)
		{
			try
			{
				switch (command.ToUpper())
				{
					case "PLACE":
						PlaceRectangles(parameters);
						break;
					case "FIND":
						FindRectangle(parameters);
						break;
					case "REMOVE":
						RemoveRectangle(parameters);
						break;
					default:
						break;
				}
			}
			catch (Exception)
			{
				Console.WriteLine("unknown command, please enter your command again");
				throw new ArgumentException();

			}

		}

		public bool PlaceRectangles(string parameters)
		{
			Position position = Position.ParsePositionParameters(parameters);
			int x = X.Find(a => a > position.X);
			int y = Y.Find(b => b > position.Y);
			if (x > 0 || y > 0)
			{
				Console.WriteLine("rectangle can not be overlap");
			}
			else
			{
				X.Add(position.X);
				Y.Add(position.Y);
				ValidateRectangleCurrentPosition(position.X, position.Y);
				return true;
			}
			return false;
		}

		public void RemoveRectangle(string parameters)
		{
			string[] paramArray = parameters.Split(',');

			int newXPOS = int.Parse(paramArray[0]);
			int newYPOS = int.Parse(paramArray[1]);

			if (!IsValidRectanglePosition(newXPOS, newYPOS))
			{
				Console.WriteLine("Invalid command. This move will place rectangle in an invalid position");
			}
			if (X.Contains(newXPOS) && Y.Contains(newYPOS))
			{
				X.Remove(newXPOS);
				Y.Remove(newYPOS);
				Console.WriteLine("The rectangle has removed from the grid");
			}
			else
			{
				Console.WriteLine("The rectangle does not exist");
			}
		}

		public void FindRectangle(string parameters)
		{
			string[] paramArray = parameters.Split(',');

			int newXPOS = int.Parse(paramArray[0]);
			int newYPOS = int.Parse(paramArray[1]);

			if (X.Contains(newXPOS) && Y.Contains(newYPOS))
            {
				Console.WriteLine("rectangle found, the cordinates are " + newXPOS + " and " + newYPOS);
			}
			else
				Console.WriteLine("rectangle is not found based on given cordinates.");
		}
		public void ValidateGridPosition(string gridCordinates)
		{
			string[] cordinates = gridCordinates.Split(",");
			int x = int.Parse(cordinates[0]);
			int y = int.Parse(cordinates[1]);

			if (!IsValidGridPosition(x, y))
			{
				Console.WriteLine("Invalid grid command");
				throw new ArgumentException();
			}
		}
		private bool IsValidGridPosition(int? x, int? y)
		{
			return x.HasValue && y.HasValue
				&& x >= 5 && y <= 25;
		}
		private void ValidateRectangleCurrentPosition(int x, int y)
		{
			if (!IsValidRectanglePosition(x, y))
			{
				Console.WriteLine("Invalid command. rectangle isn't placed correctly");
			}
		}
		private bool IsValidRectanglePosition(int? x, int? y)
		{
			return x.HasValue && y.HasValue
				&& x >= 0 && y >= 0 && y <= 25;
		}

	}
}

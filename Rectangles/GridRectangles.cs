using System;
using System.Collections.Generic;

namespace RectanglesCommands
{
    class GridRectangles
    {
        static void Main(string[] args)
        {
			Rectangles rectangle = new Rectangles();
            try
            {

                Console.WriteLine("Please enter grid height and width.");
				string grid = Console.ReadLine();
				rectangle.ValidateGridPosition(grid);

                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("Please enter command");

					var command = Console.ReadLine();
					if (command.ToUpper() == "PLACE")
					{
						Console.WriteLine("Please enter rectangle cordinates to place it.");
						var Parameter  = Console.ReadLine();
						rectangle.ExecuteCommand(command, Parameter);

					}
					if (command.ToUpper() == "FIND")
					{
						Console.WriteLine("Please enter rectangle cordinates to find it.");
						var Parameter = Console.ReadLine();
						rectangle.ExecuteCommand(command, Parameter);
					}
					if (command.ToUpper() == "REMOVE")
					{
						Console.WriteLine("Please enter rectangle cordinates to remove it.");
						var Parameter = Console.ReadLine();
						rectangle.ExecuteCommand(command, Parameter);
					}
				}
			}
			catch (Exception)
            {
				
            }
		}
    }
	
}

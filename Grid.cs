using System;

namespace Battleship
{
	public class Grid
	{
		//Variable for the grid - using Constants for the row and column number
		readonly String[,] grid = new String[Constants.END_FIELD_X, Constants.END_FIELD_Y];

		/*
		 * Method to create the base grid of the game. 
		 */
		public void CreateGrid()
		{

			//Fill up the first row of the grid with indexes
			// 0 to 20 (had to adjust the GetLength to include the number 20)
			// First cell should not display 0, since it is not yet the beginning of the grid but the first column filled up with indexes
			Console.Write("---|--| ");
			for (int a = 1; a < grid.GetLength(0); a++)
			{
				if (a >= 10)
				{
					Console.Write(a + " | ");
				}
				else if (a < 10)
				{
					Console.Write(a + "  | ");
				}
			}


			for (int i = 1; i < grid.GetLength(0); i++)
			{
				//Fill up the first column of the grid with indexes (different spaces for numbers from 10 on,
				//just a design matter)
				// 0 to 19
				// First cell should not display 0, since it is not yet the beginning of the grid but the first row filled up with indexes


				Console.Write("\n");


				if (i < 10)
				{
					Console.Write(i + "  |");
				}
				else if (i >= 10)
				{
					Console.Write(i + " |");
				}


				//Grid
				for (int j = 1; j < grid.GetLength(0); j++)
				{
					Console.BackgroundColor = ConsoleColor.Green;

					Console.Write(grid[i, j] + "  |  ");
					/*
					 * if (j == 10 && i == 1)
					{ 
						Console.Write(grid[(Convert.ToInt16(j) - 1), i] + "10-1");
					}

					if (j == 10 && i == 10)
					{ 
						Console.Write(grid[(Convert.ToInt16(j) - 1), i] + "10-10");
					}
					*/
				}
			}
			Console.Write("\n\n");
			Console.ResetColor();
		}




	}
}

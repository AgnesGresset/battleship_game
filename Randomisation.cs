using System;
namespace Battleship
{
	public class Randomisation
	{
		readonly Random Random = new Random();
		Constants Constants = new Constants();

		public int getRandom()
		{
			//Variables
			int rand;
			return rand = Random.Next(1, 21);
		}

		/*
         * Random STARTING coordinates for any type of boats considering their length, 
         * so that they would not go beyong the boundaries of the grid.
         * Example: Warships length = 5 cells in total (but only 4 will be counted in constants,
         * since the starting cell is also counted in the calculation)
		 */
		public int getStartX(string boatType)
		{
			//Variables
			int start_x;
			int RandomPerBoatTypes = Convert.ToInt16(Constants.getLengthPerBoatType(boatType));
			return start_x = Random.Next(Constants.START_FIELD_X, Constants.END_FIELD_X - RandomPerBoatTypes);
		}

		public int getStartY(string boatType)
		{
			//Variables
			int start_y;
			int RandomPerBoatTypes = Convert.ToInt16(Constants.getLengthPerBoatType(boatType));
			return start_y = Random.Next(Constants.START_FIELD_Y, Constants.END_FIELD_Y - RandomPerBoatTypes);
		}

		/*
		 * Randomisation of direction
		 */
		public int getDirection()
		{
			//Variables
			int rand;
			rand = Random.Next(1, 101);
			return rand % 2;
		}
	}
}

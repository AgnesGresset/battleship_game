using System;
using System.Collections.Generic;

namespace Battleship

{
	public class Boats
	{
		Randomisation Randomisation = new Randomisation();
		Constants Constants = new Constants();

		/*
		 * Static methods were an attempt to create a STATIC list of boat coordinates that would not be regenerated 
		 * each time i call the PlayGame() method.
		 * Needs to be removed when refactoring
		 */ 
		static int startCoordinatesX(string BoatType)
		{
			Randomisation Randomisation = new Randomisation();
			int boat_start_X = Randomisation.getStartX(BoatType);
			return boat_start_X;
		}

		static int startCoordinatesY(string BoatType)
		{
			Randomisation Randomisation = new Randomisation();
			int boat_start_Y = Randomisation.getStartY(BoatType);
			return boat_start_Y;
		}


		/*
		* Method to place the boats at the beginning of the game.  
		*/
		public List<int> PlaceWarship()
		{
			/* Each boat has to get a coordinates array with start_x and start_y coordinates
			 * Example:[2, 5]
			 * Once they are assigned coordinate values, their length will be added -
			 * Boats length will only be added horizontally to the right and vertically to the bottom of the boat
			 * A boat starting at Column 2 and Row 5 can only span over Column 2 by going down and Row 5 by going right
			 * At the end of the process, boats have as many coordinate arrays as they are long
			 * Example: a warship has 5 coordinate arrays: [2, 5], [3, 5], [4, 5], [6, 5], [7, 5].
			 * 
			 */
			Dictionary<string, int> boatsTypes = Constants.BoatsNumberPerBoatTypes();
			List<int> start_coordinates = CoordinatesList();

			foreach (var boatsNumberPerType in boatsTypes)
			{
				for (int i = 1; i <= Convert.ToInt16(boatsNumberPerType.Value); i++)
				{
					// Variables
					int boat_start_X = Randomisation.getStartX(boatsNumberPerType.Key);
					int boat_start_Y = Randomisation.getStartY(boatsNumberPerType.Key);
					Console.WriteLine("boat_start_X = {0}", boat_start_X);
					Console.WriteLine("boat_start_Y = {0}", boat_start_Y);


					// According to length of each type of boat
					var boatsLength = Constants.getLengthPerBoatType(boatsNumberPerType.Key);

					// Random direction - Horizontal is result of % == 0
					if (Randomisation.getDirection() == 0)
					{
						getCoordinatesX(boatsLength, boat_start_X, boat_start_Y, start_coordinates);
					}
					// Random direction - Vertical is % != 0
					else
					{
						getCoordinatesY(boatsLength, boat_start_X, boat_start_Y, start_coordinates);
					}
				}
			}
			// returns the lists of coordinates for each boat
			return new List<int>(start_coordinates);
		}

		// Returns a static list
		static List<int> CoordinatesList()
		{
			List<int> CoordinatesRange = new List<int>();
			return CoordinatesRange;
		}

		/*
         * Gets the staring coordinates of each boats.According to each boat, their corresponding length will then be added 
         * to "create" all the boats with their complete coordinates.
         * getCoordinatesX creates all X starting coordinates
		 */ 
		public void getCoordinatesX(int boatsLength, int boat_start_X, int boat_start_Y, List<int> start_coordinates)
		{
			// Length according to boat type
			for (int j = 0; j <= boatsLength; j++)
			{
				if (boat_start_X <= Constants.END_FIELD_X
				&& boat_start_Y <= Constants.END_FIELD_Y)
				{
					// Creation of array with starting coordinates - avoiding corners
					if ((boat_start_X == 1 && boat_start_Y == 1)
						// the next cases can theoretically never happen, since boats are placed by taking into account their length.
						|| (boat_start_X == 1 && boat_start_Y == 20)
						|| (boat_start_X == 20 && boat_start_Y == 1)
						|| (boat_start_X == 20 && boat_start_Y == 20))
					{
						// the console writeline should also be removed when refactoring
						Console.WriteLine("Boat was in a corner " + boat_start_X + " " + boat_start_Y);
						start_coordinates.Add(Randomisation.getRandom() + j);
						start_coordinates.Add(boat_start_Y);
					}
					start_coordinates.Add(boat_start_X + j);
					start_coordinates.Add(boat_start_Y);
				}
			}
		}

		/*
		 * getCoordinatesY creates all Y starting coordinates	 
		 */
		public void getCoordinatesY(int boatsLength, int boat_start_X, int boat_start_Y, List<int> start_coordinates)
		{
			for (int j = 0; j <= boatsLength; j++)
			{
				if (boat_start_X <= Constants.END_FIELD_X
				&& boat_start_Y <= Constants.END_FIELD_Y)
				{
					// Creation of array with starting coordinates - avoiding corners
					if ((boat_start_X == 1 && boat_start_Y == 1)
					// the next cases can theoretically never happen, since boats are placed by taking into account their length.
					|| (boat_start_X == 1 && boat_start_Y == 20)
					|| (boat_start_X == 20 && boat_start_Y == 1)
					|| (boat_start_X == 20 && boat_start_Y == 20))
					{
						// the console writeline should also be removed when refactoring
						Console.WriteLine("Boat was in a corner " + boat_start_X + " " + boat_start_Y);
						start_coordinates.Add(boat_start_X);
						start_coordinates.Add(Randomisation.getRandom() + j);
					}
					start_coordinates.Add(boat_start_X);
					start_coordinates.Add(boat_start_Y + j);
				}
			}
		}
	}
}
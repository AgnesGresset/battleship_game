using System;
using System.Collections.Generic;

namespace Battleship
{
	public class Constants
	{
		// Constants for grid
		public const int START_FIELD_X = 1;
		public const int END_FIELD_X = 21;
		public const int START_FIELD_Y = 1;
		public const int END_FIELD_Y = 21;

		// Constants for boats length - 
		// 1 will be substracted each time since the first cell already counts in the coordinates calculation
		public const int WARSHIP_LENGTH = 4;    // 5 - 1
		public const int CRUISER_LENGTH = 3;    // 4 - 1
		public const int DESTROYER_LENGTH = 2;  // 3 - 1
		public const int U_BOAT_LENGTH = 1;     // 2 - 1

		//Constants for number of boats
		public const int WARSHIP_NUMBER = 1;
		public const int CRUISER_NUMBER = 0;
		public const int DESTROYER_NUMBER = 1;
		public const int U_BOAT_NUMBER = 1;

		// Total of points that represent every cell where a boat is placed
		// 1 needs to be added to each boat's lentgh, since it was retrieved in the constant lentghs above
		public const int TOTAL_GAMEWON = (WARSHIP_LENGTH + 1) * WARSHIP_NUMBER + (CRUISER_LENGTH + 1) * CRUISER_NUMBER + (DESTROYER_LENGTH + 1) * DESTROYER_NUMBER + (U_BOAT_LENGTH + 1) * U_BOAT_NUMBER;

		// Total of points that represent every water cell
		public const int TOTAL_WATER = ((END_FIELD_X - START_FIELD_X) * (END_FIELD_Y - START_FIELD_Y)) - TOTAL_GAMEWON;

		/*
		* Randomisation according to type of boats
		* Wy can't i write break??
		*/
		public int getLengthPerBoatType(string boatType)
		{
			// Switch Case
			switch (boatType)
			{
				case "Warship":
					return Convert.ToInt16(WARSHIP_LENGTH);
				//break;
				case "Destroyer":
					return Convert.ToInt16(DESTROYER_LENGTH);
				//break;
				case "Cruiser":
					return Convert.ToInt16(CRUISER_LENGTH);
				//break;
				case "U_Boat":
					return Convert.ToInt16(U_BOAT_LENGTH);
				//break;
				default:
					return 0;
			}
		}

		/*
		* Returns number of boats per boat type
		*/
		public Dictionary<string, int> BoatsNumberPerBoatTypes()
		{
			return new Dictionary<string, int>
			{
				{"Warship", WARSHIP_NUMBER},
				{"Cruiser", CRUISER_NUMBER},
				{"Destroyer", DESTROYER_NUMBER},
				{"U_Boat", U_BOAT_NUMBER}
			};
		}
	}
}

using System;
using System.Collections.Generic;

namespace Battleship
{
	public class Game
	{

		public int PlayGame()
		{
			int gridWithBoats = GetGridWithBoats();
			return gridWithBoats;
		}

		/*
		 * Attempt to create a STATIC list of boat coordinates that would not be regenerated each time I call the function PlayGame().
		*/
		static int GetGridWithBoats()
		{
			Boats Boats = new Boats();
			InputOutput InputOutput = new InputOutput();
			Grid Grid = new Grid();

			var ships = Boats.PlaceWarship();
			//var shipsSecondTime = Boats.PlaceWarship();
			int hitCounter = 0;
			bool hit = false;


			//Player Input for Column & Row Number:
			Console.Write("So gimme a column number: ");
			var input_column = InputOutput.ColumnInput();
			Console.Write("Now gimme a row number: ");
			int input_row = InputOutput.RowInput();


			/*
             * Loops through all the boats and their lengths to check if they correspond to the player's inputs.
             * If there is a hit, a "hitCounter" will be incremented. A boolean "hit" will also be set to true.
             * If the player misses the boats, the "hitCounter" will not be incremented. The "hit" boolean stays set on false.
			 */
			for (var i = 0; i < ships.Count /*&& i < shipsSecondTime.Count*/; i++)
			{
				Console.WriteLine("ships[i]");
				Console.WriteLine("{0}", ships[i]);

				// This could be simplified to just use "i" in the conditions below
				int index_i = i;
				Console.WriteLine("this is the index of i =" + index_i);

				// Only check the odd indexes of the coordinates array for COLUMN player input
				bool bool_column = (i + 1) % 2 != 0 && input_column == ships[i];

				if (bool_column)
				{
					for (int j = 0; j < ships.Count; j++)
					{
						Console.WriteLine("ships[j]");
						Console.WriteLine("{0}", ships[j]);

						// Only check the even indexes of the coordinates array for ROW player input
						// WARNING! Had to add 1 to the index of i so that it corresponds to the index of j
						bool bool_row = (j + 1) % 2 == 0 && j == index_i + 1 && input_row == ships[j];

						Console.WriteLine("this is the index of j =" + j);

						if (bool_column && bool_row)
						{
							// This is only way to check in the console if the index of i is equal to the index of j
							int index_i_plus_1_for_console = index_i + 1;
							Console.WriteLine("index_i + 1 == index_j: [{0}{1}{2}]", index_i_plus_1_for_console, '=', j);

							// this should be removed when refactoring
							Console.WriteLine("That's a hit! Well done [{0}{1}{2}]", ships[i], ',', ships[j]);
							//hitCounter++;
							hit = true;
							Console.WriteLine("HitQueue: ");
							AddToHitQueue(input_column, input_row);
							//getHitCoordinates(input_column, input_row);
							Console.WriteLine("\n\n");
							break;
						}
					}
				}
			}


			if (hit == false)
			{
				Console.WriteLine("Plouf! Too bad, there was nothing there, try again!\n");
			}
			else
			{
				Console.WriteLine("That's a hit! Well done! Keep playing!\n");
				hitCounter++;
				hit = false;
			}
			Console.WriteLine("hitCounter = {0}", hitCounter.ToString());

			return hitCounter;

		}

		/*
		* Attempt to create a queue adding and saving all the hit cells // this is returning an empty queue!
		*/
		static Queue<int> AddToHitQueue(int coordinate_X, int coordinate_Y)
		{
			Queue<int> HitQueue = new Queue<int>();

			//Console.WriteLine("{0}, {1}", coordinate_X, coordinate_Y);
			int[] hitCoordinates = new int[HitQueue.Count];

			HitQueue.CopyTo(hitCoordinates, 0);

			for (int i = 0; i < hitCoordinates.Length; i++)
			{
				//Console.WriteLine("{0}", hitCoordinates[i]);
				HitQueue.Enqueue(coordinate_X);
				HitQueue.Enqueue(coordinate_Y);

			}
			Console.WriteLine("{0}", string.Join(",", HitQueue));
			return HitQueue;
		}
	}
}

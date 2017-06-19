using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
	class MainClass
	{

		public static void Main(string[] args)
		{
			//Objects that will be used to call methods
			Grid Grid = new Grid();
			InputOutput InputOutput = new InputOutput();
			// this will be removed once the game is displaced to Game class and Game class will be added here
			//Boats Boats = new Boats();
			Game Game = new Game();

			//Welcome message
			InputOutput.WelcomeInput();

			// Create the base grid of the game and "places" the boats randomly on the grid
			Grid.CreateGrid();


			/* As long as the TOTAL_GAMEWON hasn't been reached, the player will keep being asked to shoot
			 * As soon as the TOTAL_GAMEWON has been reached, the Success Message will be displayed
			 * If the TOTAL_WATER is reached, the game over message will be displayed
			 */
			var play = Game.PlayGame();
			while (play < Constants.TOTAL_GAMEWON)
			{
				Grid.CreateGrid();
				Console.Write("\n\n\n");
				Game.PlayGame();
				Console.Write("\n\n\n");

				if (play == Constants.TOTAL_GAMEWON)
				{
					InputOutput.CongratulationsMessage();
				}
				//else if ()
				//{ 
					
				//}
			}

		}
	}
}
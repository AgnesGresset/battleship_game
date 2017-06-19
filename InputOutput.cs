using System;
namespace Battleship
{
	public class InputOutput
	{
		/*
		* Just a nice and warm welcome for the incredible people playing this aMAZing game.
		*/
		public void WelcomeInput()
		{
			// Nice and polite invitation for any passing by gamer to give me column and row coordinates
			Console.Write("Hellooo! Wanna play a super dupe nice game? Battleship of the future by Agnès Gresset! " +
						  "\nCome and start! You know the rules alright?" +
						  "\nI guessed so.\n\n\n");
		}

		/*
		 * Inputs of the player for each shoot.
		 */
		public int ColumnInput()
		{
			string valueX;
			short x;

			// Nice and polite invitation for any passing by gamer to give me column and row coordinates

			//Value of x coordinate given by player
			valueX = Console.ReadLine();
			x = Convert.ToInt16(valueX);

			// If the player gives a number outside the grid range, he/she will be asked to give a new number.
			if (x > 20 || x < 1)
			{
				Console.WriteLine("Check out the grid: you need to give a number between 1 and 20");
				Console.Write("So gimme a column number: ");
				valueX = Console.ReadLine();
				x = Convert.ToInt16(valueX);
			}
			// Displays the array of coordinates in the Console
			return x;
		}

		/*
		* Inputs of the player for each shoot.
		*/
		public int RowInput()
		{
			string valueY;
			short y;

			//Value of y coordinate given by player
			valueY = Console.ReadLine();
			y = Convert.ToInt16(valueY);

			// If the player gives a number outside the grid range, he/she will be asked to give a new number.
			if (y > 20 || y < 1)
			{
				Console.WriteLine("Check out the grid: you need to give a number between 1 and 20");
				Console.Write("So gimme a column number: ");
				valueY = Console.ReadLine();
				y = Convert.ToInt16(valueY);
			}
			// Displays the array of coordinates in the Console 
			return y;
		}

		/*
		* Hit messages
		*/
		public void HitSuccess()
		{
			// Success message when player has hit a boat
			Console.Write("That's a hit! Well done! Keep playing\"\n\n\n");
		}

		public void HitFailure()
		{
			// Success message when player has hit water
			Console.Write("Plouf! That didn't hit anything, keep on trying\"\n\n\n");
		}

		/*
		* Game over messages
		*/
		public void CongratulationsMessage()
		{
			// Success message when player has hit all boats on the grid
			Console.Write("GAME WON! You've made it, well done. You can start a new game if you want!\"\n\n\n");
		}

		public void GameOverMessage()
		{
			// Success message when player has only hit water (!)
			Console.Write("GAME OVER! Sorry, you've been defeated, but that's just that one time, start a new game to try again!\"\n\n\n");
		}
	}
}

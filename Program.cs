using System;
using System.Linq;
using System.Collections.Generic;

using static Tic_Tac_Toe.Move.Turn;
using static Tic_Tac_Toe.Helpers.Helpers;
using static Tic_Tac_Toe.Core.Game;
using static Tic_Tac_Toe.Core.Constants;


namespace Tic_Tac_Toe
{
    class Program
    {
		// DO NOT CHANGE
		
        public static void Main()
        {
            InitGame();
            PrintBord();

            string input ;
            int[] coords;
            bool result = true;
            do 
            {
                Console.Write("Enter the position (ex. b2): ");
                input = Console.ReadLine().ToLower();
				
				if (input.Length >= n) 
				{
					input = input.Substring(0, n - 1);
				}
				else if (input == string.Empty) 
				{
                    continue;
				}
				
                coords = input.Select(symbol => (int) symbol).ToArray();

                coords[0] -= 97;
                coords[1] -= 49;

                if ((coords[0] < 0 || coords[0] >= n) || (coords[1] < 0 || coords[1] >=n))
                {
                    Console.WriteLine(" Invalid position");
                    continue;
                }  

                result = DoStep(coords[0], coords[1]);

                if (!result) 
                {
                    Console.WriteLine(" Cell is already occupied");
                    continue;
                }
				Console.Clear();
				
                if (!IsFreeCell())
                {
                    PrintBord();
                    EndGame();
					Console.WriteLine("You plays: " + input);
                    Console.WriteLine("Draw!");
                }
                else
                {
                    if (CheckIsPlayerWin(Figure.Tic))
                    {
                        PrintBord();
                        EndGame();
						Console.WriteLine("You plays: " + input);
                        Console.WriteLine("You win!");
                    }
                    else 
                    {
                        string turn = ComputerPlay();
                        PrintBord();
						Console.WriteLine("You plays: " + input);
                        Console.WriteLine("Computer plays: " + turn);

                        if (CheckIsPlayerWin(Figure.Tac))
                        {
                            EndGame();
                            Console.WriteLine("You lost!");
                        }
                    }
                }
                
            } while (game);
        } 
    }
}

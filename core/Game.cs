using System;
using System.Collections.Generic;

using static Tic_Tac_Toe.Core.Constants;

namespace Tic_Tac_Toe.Core
{
    public class Game
    {
        public static Figure [,] board;
        public static List<Figure>[] registers;
        public static bool game;

        
        public static void EndGame()
        {
            game = false;
        }

        public static void InitGame()
        {
            board = new Figure[n, n];
            registers = new List<Figure>[n * n - 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i, j] = Figure.Nothing;

                    if (n * i + j < SECONDARY_DIAGONAL + 1) 
                    {
                        registers[n * i + j] = new List<Figure>(n);
                    }
                }
            }   

            game = true;
        }

        public static void PrintBord() 
        {
            string figure = "";
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{(char)(97 + i)} ");
                for (int j = 0; j < n; j++)
                {
                    switch (board[i, j]) 
                    {
                        case Figure.Nothing: 
                            figure = "[   ]";
                            break;
                        case Figure.Tac:
                            figure = "[ O ]";
                            break;
                        case Figure.Tic:
                            figure = "[ X ]";
                            break;
                    } 
                    
                    Console.Write(figure + "\t");
                }
                Console.WriteLine();
            }  
            Console.WriteLine("    1  \t  2  \t  3  ");
        }
    
    }
}

using System;
using System.Linq;
using static Tic_Tac_Toe.Core.Game;
using static Tic_Tac_Toe.Core.Constants;

namespace Tic_Tac_Toe.Helpers
{
    public class Helpers
    {
        public static void FindFreeCornerCell(ref int row, ref int column)
        {
            Random rnd = new Random();
            int[] corners = { 0, n - 1 };
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[corners[i], corners[j]] == Figure.Nothing)
                    {
                        row = corners[i];
                        column = corners[j];
                        return;
                    }
                }
            }
        }
        public static void FindFreeCell(int registerIndex, ref int row, ref int column)
        {
            if (registerIndex >= n) 
            {
                for (int i = 0; i < n; i++) 
                {
                    if (registerIndex == MAIN_DIAGONAL) 
                    {
                        if (board[i, i] == Figure.Nothing) 
                        {
                            row = column = i;
                        }
                    }
                    else if (registerIndex == SECONDARY_DIAGONAL)
                    {
                        if (board[i, n - i - 1] == Figure.Nothing) 
                        {
                            row = i;
                            column = n - i - 1;
                        }
                    }
                    else
                    {
                        column = registerIndex - n;
                        if (board[i, column] == Figure.Nothing) row = i;
                    }
                }

            } 
            else
            {
                row = registerIndex;
                for (int i = 0; i < n; i++) 
                {
                    if (board[row, i] == Figure.Nothing) column = i;
                }
            }
        }
        public static bool IsFreeCell()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i, j] == Figure.Nothing) return true;
                }
            }

            return false;
        }
        public static bool CheckIsPlayerWin(Figure winnerPlayerFigure)
        {
            int register = Array.FindIndex(registers, register => register.All(figure => figure == winnerPlayerFigure) && register.Count == n);

            if (register != -1)
            {
                return true;
            }

            return false;

        }
    }
}

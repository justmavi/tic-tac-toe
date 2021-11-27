using System;
using System.Linq;

using static Tic_Tac_Toe.Core.Game;
using static Tic_Tac_Toe.Core.Constants;
using static Tic_Tac_Toe.Helpers.Helpers;

namespace Tic_Tac_Toe.Move 
{
  static class Turn 
  {
    public static bool DoStep(int row, int column, Figure figure = Figure.Tic)
    {
        if (board[row, column] != Figure.Nothing) 
        {
            return false;
        }

        board[row, column] = figure;
        AddToRegister(row, column, figure);

        return true;
    }

    public static void AddToRegister(int row, int column, Figure figure)
        {
            int rowRegister = row;
            int columnRegister = n + column;

            registers[rowRegister].Add(figure);
            registers[columnRegister].Add(figure);

            if (row == column) registers[MAIN_DIAGONAL].Add(figure);
            if (row == n - column - 1) registers[SECONDARY_DIAGONAL].Add(figure);
        }
    public static string ComputerPlay()
    {
        int register = Array.FindIndex(registers, register => register.Count(figure => figure == Figure.Tac) == n - 1 && register.Count == n - 1);
        int row = -1;
        int column = -1;

        if (register == -1) 
        {
            register = Array.FindIndex(registers, register => register.Count(figure => figure == Figure.Tic) == n - 1 && register.Count == n - 1);
            if (register == -1) 
            {
                if (board[n / 2, n / 2] == Figure.Nothing) 
                {
                    row = column = n / 2;
                }
                else
                {
                    register = Array.FindIndex(registers, register => register.Count(figure => figure == Figure.Tac) == 1 && register.Count == 1);
                    if (register == -1) FindFreeCornerCell(ref row, ref column);
                    else FindFreeCell(register, ref row, ref column);

                }
            }
            else
            {
                FindFreeCell(register, ref row, ref column);

            }
        }
        else
        {
            FindFreeCell(register, ref row, ref column);
        }

        DoStep(row, column, Figure.Tac);

        return $"{(char)(row + 97)}{column + 1}";
    }
  }
}
using System;
using System.Collections.Generic;

namespace Game
{
    internal static class Program
    {
        private static void Main()
        {
            var board = new List<string>();
            for (var i = 0; i < 9; i++)
                board.Add(" ");

            while (true)
            {
                PrintBoard();
                PlayerMove("X");
                PrintBoard();
                if (IsVictory("X"))
                {
                    Console.WriteLine("X Wins! Contratulations!");
                    break;
                }
                if (IsDraw())
                {
                    Console.WriteLine("It's a draw!");
                    break;
                }

                PlayerMove("O");
                if (IsVictory("O"))
                {
                    Console.WriteLine("\nO Wins! Contratulations!");
                    break;
                }
                if (!IsDraw()) continue;
                Console.WriteLine("\nIt's a draw!");
                break;
            }

            void PrintBoard()
            {
                var row1 = $"| {board[0]} | {board[1]} | {board[2]} |";
                var row2 = $"| {board[3]} | {board[4]} | {board[5]} |";
                var row3 = $"| {board[6]} | {board[7]} | {board[8]} |";

                Console.WriteLine();
                Console.WriteLine(row1);
                Console.WriteLine(row2);
                Console.WriteLine(row3);
                Console.WriteLine();
            }

            void PlayerMove(string icon)
            {
                var number = 0;
                switch (icon)
                {
                    case "X":
                        number = 1;
                        break;
                    case "O":
                        number = 2;
                        break;
                }

                Console.WriteLine($"Your turn player {number}: \n");
                Console.WriteLine("Enter your move (1-9)");
                var choice = Convert.ToInt32(Console.ReadLine());

                if (board[choice - 1] == " ")
                    board[choice - 1] = icon;
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("That space is taken!");
                    PlayerMove(icon);
                }
            }

            bool IsVictory(string player)
            {
                return (board[0] == player && board[1] == player && board[2] == player) ||
                       (board[3] == player && board[4] == player && board[5] == player) ||
                       (board[6] == player && board[7] == player && board[8] == player) ||
                       (board[0] == player && board[3] == player && board[6] == player) ||
                       (board[1] == player && board[4] == player && board[7] == player) ||
                       (board[2] == player && board[5] == player && board[8] == player) ||
                       (board[0] == player && board[4] == player && board[8] == player) ||
                       (board[2] == player && board[4] == player && board[6] == player);
            }

            bool IsDraw()
            {
                return !board.Contains(" ");
            }
        }
    }
}

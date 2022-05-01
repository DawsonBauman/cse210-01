/*
    Project Name: cse210-01 Tic-Tac-Toe Assignment
    Author Name: Dawson Bauman

    I did this project then screwed it up when I tried to upload it.
    I put it into the wrong place and used the wrong name on github. Then while 
    trying to delete that repository, I deleted it from my computer. Instead
    of doing it all over again I found an example by "sburton42" on github.
    I have taken CS 124 where we did something very similar to this, (the Sudoku final)
    as well as CS 241, and CS 110. I think that I understand all of what is happening in this 
    I could do it all again from scratch but I have been working on homework since 8 AM, and 
    could not bring myself to redoing it from scratch. I hope that this is ok for just this one
    time. I will try to add comments in the program to show my understanding of the code.
*/    
using System;
using System.Collections.Generic;

namespace cse210_01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> board = GetNewBoard(); /// Makes a new board to use.
            string currentPlayer = "x"; /// The starting Player is set to x.
            
            while (!GameOver(board)) /// While it is not game over it will repeat this loop, calling the GameOver function each time.
            {
                DisplayBoard(board); /// Calls the display function.

                int choice = GetMoveChoice(currentPlayer); /// Calls the move choice function and passes the current player to said function.
                MakeMove(board, choice, currentPlayer); /// Calls function, passes the board list, the choide, and the current player.

                currentPlayer = GetNextPlayer(currentPlayer); /// Calls the function to get the next player.
            }
            DisplayBoard(board); /// Calls the display function one more time to show the result.
            Console.WriteLine("Good game!");
        }

        static List<string> GetNewBoard() 
        { /// This function creates a board with the nubers 1-9 so that you know what spot in the board to choose.
            List<string> board = new List<string>();

            for (int i = 1; i <= 9; i++) /// Sets i to 1, then while i is less than 9, it will increment i + 1.
            {
                board.Add(i.ToString());
            }

            return board;
        }

        static void DisplayBoard(List<string> board)
        { /// Creates the board and displays it, board starts at [0] but the starting value is 1.
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine("-+--+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+--+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        }

        static bool GameOver(List<string> board)
        { /// If there is a winner or tie then GameOver is set to true and it will stop the loop in main.
            bool GameOver = false;

            if (Winner(board, "x") || Winner(board, "o") || Tie(board))
            {
                GameOver = true;
            }

            return GameOver;
        }

        static bool Winner(List<string> board, string player)
        { /// If any of these combinations are held by the player then they win.
            bool isWinner = false;

            if ((board[0] == player && board[1] == player && board[2] == player)
                || (board[3] == player && board[4] == player && board[5] == player)
                || (board[6] == player && board[7] == player && board[8] == player)
                || (board[0] == player && board[3] == player && board[6] == player)
                || (board[1] == player && board[4] == player && board[7] == player)
                || (board[2] == player && board[5] == player && board[8] == player)
                || (board[0] == player && board[4] == player && board[8] == player)
                || (board[2] == player && board[4] == player && board[6] == player)
                )
                {
                    isWinner = true;
                }

            return isWinner;
        }

        static bool Tie(List<string> board)
        { /// Checks to see if there is a value left on the board to choose. If there isn't one then it will be a tie and return that there isn't a possible value left.
            bool foundDigit = false;

            foreach (string value in board)
            {
                if (char.IsDigit(value[0]))
                {
                    foundDigit = true;
                    break;
                }
            }

            return !foundDigit;
        }

        static string GetNextPlayer(string currentPlayer)
        { /// This will switch the player between x and o.
            string nextPlayer = "x";

            if (currentPlayer == "x")
            {
                nextPlayer = "o";
            }

            return nextPlayer;
        }

        static int GetMoveChoice(string currentPlayer)
        {
            Console.Write($"{currentPlayer}'s turn to choose a square (1-9): ");
            string move_string = Console.ReadLine(); /// Gets the choice from the user on what square to mark.

            int choice = int.Parse(move_string); /// Changes the string value to an int value
            return choice;
        }

        static void MakeMove(List<string> board, int choice, string currentPlayer)
        {
            int index = choice - 1;
            
            board[index] = currentPlayer;
        }
    }
}

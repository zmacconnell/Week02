using System;
using System.Collections.Generic;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> board = new List<string>{"1", "2", "3", "4", "5", "6", "7", "8", "9"};
            string playAgain = "y";
            string currentPlayer = "x"; 
            int currentRound = 1;
            while (playAgain != "n")
                while (true)
                {
                    Console.Write($"Player {currentPlayer}'s turn (1-9): ");
                    string playersChoice = Console.ReadLine();
                    writeBoard(board);
                    gameOver(board, currentRound, currentPlayer);
                    currentPlayer = playersTurn(currentPlayer);
                    
                    break;
                    currentRound = currentRound + 1;
                }
            Console.Write("Would you like to play again (y/n): ");
            playAgain = Console.ReadLine();
        }
        static void writeBoard(List<string> board)
        {
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        }
        static void changeBoard(string userInput)
        {
            break;
        }
        static string playersTurn(string currentTurn)
        {
            if (currentTurn == "x")
            {
                currentTurn = "y";
            }
            else if (currentTurn == "y")
            {
                currentTurn ="x";
            }
            return currentTurn;
        }
        static int gameOver(List<string> board, int currentRound, string currentPlayer)
        // Inputs: List of spaces, Current turn
        // 0 = keep playing, 1 = x wins, 2 = y wins, 3 = draw
        {
            if (currentPlayer == "x")
            {
                int gameState = 1;
            }
            else if (currentPlayer == "y")
            {
                int gameState = 2;
            }
            else if (currentRound == 9)
            {
                int gameState = 3;
            }
            else
            {
                int gameState = 0;
            }
            
            return gameState;
        }
    }
}
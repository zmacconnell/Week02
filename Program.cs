using System;
using System.Collections.Generic;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string playAgain = "y";
            do
            {
                if (playAgain == "n")
                {
                    break;
                }
                List<string> board = new List<string>{"1", "2", "3", "4", "5", "6", "7", "8", "9"};
                string currentPlayer = "x"; 
                int currentRound = 1;
                writeBoard(board);

                while (playAgain != "n")
                {
                    int gameState = 0;
                    Console.Write($"Player {currentPlayer}'s turn (1-9): ");
                    string playersChoice = Console.ReadLine();
                    if (board.Contains(playersChoice))
                    {
                        changeBoard(playersChoice, board, currentPlayer);
                        writeBoard(board);
                        gameState = gameStateCheck(board, currentRound, currentPlayer, gameState);
                        if (gameState != 0)
                        {
                            Console.WriteLine("Game Over!");
                            if (gameState == 1)
                            {
                                Console.WriteLine($"Player {currentPlayer} Wins!");
                                Console.Write("Would you like to play again (y/n): ");
                                playAgain = Console.ReadLine();
                                break;
                            }
                            else if (gameState == -1)
                            {
                                Console.WriteLine("It's a draw!");
                                Console.Write("Would you like to play again (y/n): ");
                                playAgain = Console.ReadLine();
                                break;
                            }
                        }
                    }
                    currentPlayer = changePlayersTurn(currentPlayer);
                    currentRound = currentRound + 1;
                } 
            } while (playAgain != "n"); 
            Console.WriteLine("Thank you for playing!");       
        }
        static void writeBoard(List<string> board)
        {
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        }
        static void changeBoard(string userInput, List<string> board, string currentPlayer)
        {
            int spot = int.Parse(userInput);
            spot = spot - 1;
            board[spot] = currentPlayer;
        }
        static string changePlayersTurn(string currentTurn)
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
        static int gameStateCheck(List<string> board, int currentRound, string currentPlayer, int gameState)
        // Inputs: List of spaces, Current turn
        // 0 = keep playing, 1 = winner, -1 = draw
        {
            gameState = 0;
            if ((board[0] == currentPlayer && board[1] == currentPlayer && board[2] == currentPlayer) ||
            (board[3] == currentPlayer && board[4] == currentPlayer && board[5] == currentPlayer) || 
            (board[6] == currentPlayer && board[7] == currentPlayer && board[8] == currentPlayer) ||
            (board[0] == currentPlayer && board[5] == currentPlayer && board[8] == currentPlayer) ||
            (board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer) ||
            (board[0] == currentPlayer && board[3] == currentPlayer && board[6] == currentPlayer) ||
            (board[1] == currentPlayer && board[4] == currentPlayer && board[7] == currentPlayer) ||
            (board[2] == currentPlayer && board[5] == currentPlayer && board[8] == currentPlayer))
            {
                gameState = 1;
            }
            else if (currentRound == 9)
            {
                gameState = -1;
            }
            
            return gameState;
        }
    }
}
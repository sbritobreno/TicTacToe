using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static List<int> placeNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static char winner = ' ';

        static void Main(string[] args)
        {
            Console.WriteLine("Tic Tac Toe game!\n");

            char[,] gameBoard =
            {
                {' ', '|', ' ', '|', ' ' },
                {'-', '+', '-', '+', '-' },
                {' ', '|', ' ', '|', ' ' },
                {'-', '+', '-', '+', '-' },
                {' ', '|', ' ', '|', ' ' },
            };

            PrintGameBoard(gameBoard);
            Play(gameBoard); 

        }
        public static void Play(char[,] gBoard)
        {
            while (!GameOver(gBoard))
            {
                while (true) { 
                    Console.WriteLine("Player X, enter your placement (1-9)");
                    try
                    {
                    var inputX = int.Parse(Console.ReadLine());
                    if (!ValidPlace(inputX))
                    {
                        Console.WriteLine("This number is either out of range or has been already taken, try another!");
                        continue;
                    }
                    InputValue(inputX, gBoard, 'X');
                    break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Enter a Value...");
                    }
                }

                if (GameOver(gBoard))
                    break;

                while (true) {
                    Console.WriteLine("Player O, enter your placement (1-9)");
                    try
                    {

                    var inputO = int.Parse(Console.ReadLine());
                    if (!ValidPlace(inputO))
                    {
                        Console.WriteLine("This number is either out of range or has been already taken, try another!");
                        continue;
                    }
                    InputValue(inputO, gBoard, 'O');
                    break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Enter a Value...");
                    }
                }
            }
        }

        public static bool GameOver(char [,] gBoard)
        {
            // Place indexes
            var one = gBoard[0, 0];
            var two = gBoard[0, 2];
            var three = gBoard[0, 4];
            var four = gBoard[2, 0];
            var five = gBoard[2, 2];
            var six = gBoard[2, 4];
            var seven = gBoard[4, 0];
            var eight = gBoard[4, 2];
            var nine = gBoard[4, 4];

            char[] values = new char[] { one, two, three, four, five, six, seven, eight, nine };

            // Win combinations
            var comb1 = one == five && one == nine && one != ' ';
            var comb2 = three == five && three == seven && three != ' ';
            var comb3 = one == four && one == seven && one != ' ';
            var comb4 = two == five && two == eight && two != ' ';
            var comb5 = three == six && three == nine && three != ' ';
            var comb6 = one == two && one == three && one != ' ';
            var comb7 = four == five && four == six && four != ' ';
            var comb8 = seven == eight && seven == nine && seven != ' ';
 
            bool[] combinations = new bool[] { comb1, comb2, comb3, comb4, comb5, comb6, comb7, comb8 };

            if (comb1 || comb2 || comb3 || comb4 || comb5 || comb6 || comb7 || comb8)
            {
                Console.WriteLine($"{winner} wins!!!");
                return true;
            }
            else if(placeNumbers.Count == 0)
            {
                Console.WriteLine("TIE");
                return true;
            }

            return false;
        }
        public static bool ValidPlace(int input)
        {

            if (placeNumbers.Contains(input))
            {
                placeNumbers.Remove(input);
                return true;
            }
            else if (input < 0 || input > 9)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        public static void InputValue(int input, char[,] gBoard, char symbol)
        {
            switch (input)
            {
                case 1:
                    gBoard[0, 0] = symbol;
                    break;
                case 2:
                    gBoard[0, 2] = symbol;
                    break;
                case 3:
                    gBoard[0, 4] = symbol;
                    break;
                case 4:
                    gBoard[2, 0] = symbol;
                    break;
                case 5:
                    gBoard[2, 2] = symbol;
                    break;
                case 6:
                    gBoard[2, 4] = symbol;
                    break;
                case 7:
                    gBoard[4, 0] = symbol;
                    break;
                case 8:
                    gBoard[4, 2] = symbol;
                    break;
                case 9:
                    gBoard[4, 4] = symbol;
                    break;
                default:
                    break;
            }

            winner = symbol;
            PrintGameBoard(gBoard);
        }
        public static void PrintGameBoard(char [,] gBoard)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(gBoard[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

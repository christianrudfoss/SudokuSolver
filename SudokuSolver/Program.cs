using SudokuLibrary.Extensions;
using System;


namespace SudokuSolver
{
    /*
     * Todo improvements:
     * ------------------
     * 
     * List of every positions in a square with a list of possible numbers for each position.
     * List of every numbers in a square, with a list of possible locations for each number.
     */ 

    internal class Program
    {

        static void Main(string[] args)
        {       
            var puzzle = SetupPuzzle();
            Console.WriteLine("Start:");
            Console.WriteLine();
            WritePuzzle(puzzle);

            puzzle.SolvePuzzle();
            
            Console.WriteLine();
            Console.WriteLine("-----------");
            Console.WriteLine();

            Console.WriteLine("Result:");
            Console.WriteLine();

            WritePuzzle(puzzle);
        }

        private static void WritePuzzle(int[,] puzzle)
        {
            for (int rowNr = 0; rowNr < puzzle.NrOfRows(); rowNr++)
            {
                switch (rowNr)
                {
                    case 3: case 6:
                        Console.WriteLine(" ");
                        break;
                }
                for (int colNr = 0; colNr < puzzle.NrOfColumns(); colNr++)
                {
                    switch (colNr)
                    {
                        case 3: case 6:
                            Console.Write(" ");
                            break;
                    }
                    Console.Write(puzzle[rowNr, colNr]);
                }
                Console.WriteLine();
            }
        }

        public static int[,] SetupPuzzle()
        {
            int[,] puzzle = new int[9, 9] {
                //easy
                {3,0,0,0,0,2,4,0,0 },
                {1,5,7,0,9,0,3,8,0 },
                {0,0,0,3,0,7,9,0,6 },

                {0,0,0,9,0,6,0,2,7 },
                {5,0,9,0,2,0,1,0,3 },
                {6,0,2,1,0,5,8,9,0 },

                {4,0,0,0,6,9,7,0,0 },
                {7,6,0,5,8,0,0,0,0 },
                {9,2,0,4,0,0,0,0,1 }

                //medium
                //{0,6,1,9,2,0,0,0,0 },
                //{2,7,0,0,0,0,6,0,0 },
                //{0,0,0,0,1,6,2,0,3 },
                //{0,0,7,0,0,0,0,8,5 },
                //{0,0,5,0,0,0,0,0,0 },
                //{1,3,6,8,5,7,0,0,0 },
                //{0,0,0,0,9,0,5,0,0 },
                //{6,0,2,5,0,4,8,0,0 },
                //{0,5,0,3,6,0,0,0,7 }
            };
            return puzzle;
        }
    }
}

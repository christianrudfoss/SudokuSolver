using SudokuLibrary.Models;
using System;
using System.Linq;

namespace SudokuLibrary.Extensions
{
    public static class PuzzleExtensions
    {
        public enum BulkType
        {
            Horizontal,
            Vertical,
            Square
        }
        public static void SolvePuzzle(this int[,] puzzle)
        {
            int totalMissing = puzzle.NrOfRows() * puzzle.NrOfColumns();

            while (totalMissing > puzzle.NumberOfMissing())
            {
                totalMissing = puzzle.NumberOfMissing();
                puzzle.AddMissingNumbersHorizontalBulk();
                puzzle.AddMissingNumbersVerticalBulk();
                puzzle.AddMissingNumbersSquareBulk();
            }
        }
        public static int NrOfSquares(this int[,] puzzle)
        {
            return (int)Math.Sqrt(puzzle.Length);
        }
        public static int NrOfColumns(this int[,] puzzle)
        {
            return (int)Math.Sqrt(puzzle.Length);
        }
        public static int NrOfRows(this int[,] puzzle)
        {
            return (int)Math.Sqrt(puzzle.Length);
        }
        public static int NumberOfMissing(this int[,] puzzle)
        {
            int numberOfMissing = 0;
            for (int rowIndex = 0; rowIndex < puzzle.NrOfRows(); rowIndex++)
                numberOfMissing +=PuzzleProcessor.GetMissingNumbersInBulk(PuzzleProcessor.GetRowFromPuzzle(puzzle, rowIndex)).Count();

            return numberOfMissing;
        }
        public static void AddMissingNumbersHorizontalBulk(this int[,] puzzle)
        {
            for (int rowIndex = 0; rowIndex < puzzle.NrOfRows(); rowIndex++)
            {
                int[] row = PuzzleProcessor.GetRowFromPuzzle(puzzle, rowIndex);
                int[] missingNumbersInBulk = PuzzleProcessor.GetMissingNumbersInBulk(row);
                int[] emptySpaceColumnIndexes = PuzzleProcessor.GetEmptySpaceIndexInBulk(row);

                foreach (int missingNumber in missingNumbersInBulk)
                {
                    PuzzleNumberLocation puzzleNumberLocation = PuzzleProcessor.GetPuzzleNumberLocationFromHorizontal(puzzle, rowIndex, emptySpaceColumnIndexes, missingNumber);
                    if (puzzleNumberLocation != null)
                    {
                        puzzle.InsertPuzzleNumber(puzzleNumberLocation);
                        emptySpaceColumnIndexes = PuzzleProcessor.GetEmptySpaceIndexInBulk(row);
                    }
                }
            }
        }
        public static void AddMissingNumbersVerticalBulk(this int[,] puzzle)
        {
            for (int columnIndex = 0; columnIndex < puzzle.NrOfColumns(); columnIndex++)
            {
                int[] column = PuzzleProcessor.GetColumnFromPuzzle(puzzle, columnIndex);
                int[] missingNumbersInBulk = PuzzleProcessor.GetMissingNumbersInBulk(column);
                int[] emptySpaceRowIndexes = PuzzleProcessor.GetEmptySpaceIndexInBulk(column);

                foreach (int missingNumber in missingNumbersInBulk)
                {
                    PuzzleNumberLocation puzzleNumberLocation = PuzzleProcessor.GetPuzzleNumberLocationFromVertical(puzzle, columnIndex, emptySpaceRowIndexes, missingNumber);
                    if (puzzleNumberLocation != null)
                    {
                        puzzle.InsertPuzzleNumber(puzzleNumberLocation);
                        emptySpaceRowIndexes = PuzzleProcessor.GetEmptySpaceIndexInBulk(column);
                    }
                }
            }
        }
        public static void AddMissingNumbersSquareBulk(this int[,] puzzle)
        {
            for (int squareIndex = 0; squareIndex < puzzle.NrOfSquares(); squareIndex++)
            {
                int[] square = PuzzleProcessor.GetSquareFromPuzzle(puzzle, squareIndex);
                int[] missingNumbersInBulk = PuzzleProcessor.GetMissingNumbersInBulk(square);
                int[] emptySpaceSquareIndexes = PuzzleProcessor.GetEmptySpaceIndexInBulk(square);

                foreach (int missingNumber in missingNumbersInBulk)
                {
                    PuzzleNumberLocation puzzleNumberLocation = PuzzleProcessor.GetPuzzleNumberLocationFromSquare(puzzle, squareIndex, emptySpaceSquareIndexes, missingNumber);
                    if (puzzleNumberLocation != null)
                    {
                        puzzle.InsertPuzzleNumber(puzzleNumberLocation);
                        emptySpaceSquareIndexes = PuzzleProcessor.GetEmptySpaceIndexInBulk(square);
                    }
                }
            }
        }
        public static bool ColumnAlreadyContainsNumber(this int[,] puzzle, int columnIndex, int missingNumber)
        {
            return PuzzleProcessor.GetColumnFromPuzzle(puzzle, columnIndex).Where(n => n == missingNumber).Count() > 0;
        }
        public static bool RowAlreadyContainsNumber(this int[,] puzzle, int rowIndex, int missingNumber)
        {
            return PuzzleProcessor.GetRowFromPuzzle(puzzle, rowIndex).Where(n => n == missingNumber).Count() > 0;
        }
        public static void InsertPuzzleNumber(this int[,] puzzle, PuzzleNumberLocation puzzleNumberLocation)
        {
            if (puzzleNumberLocation.RowId < 0 || puzzleNumberLocation.RowId >= puzzle.NrOfRows())
                throw new ArgumentException("RowId can't be negative, or more than " + (puzzle.NrOfRows() - 1), "RowId");

            if (puzzleNumberLocation.ColumnId < 0 || puzzleNumberLocation.ColumnId >= puzzle.NrOfColumns())
                throw new ArgumentException("ColumnId can't be negative, or more than " + (puzzle.NrOfColumns() - 1), "ColumnId");

            if (puzzleNumberLocation.Value < 1 || puzzleNumberLocation.Value > puzzle.NrOfColumns())
                throw new ArgumentException("Value can't be negative, or more than " + puzzle.NrOfColumns(), "Value");

            puzzle[puzzleNumberLocation.RowId, puzzleNumberLocation.ColumnId] = puzzleNumberLocation.Value;
        }
        

    }
}

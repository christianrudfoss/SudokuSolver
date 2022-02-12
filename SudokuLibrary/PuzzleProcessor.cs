using SudokuLibrary.Extensions;
using SudokuLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLibrary
{
    public static class PuzzleProcessor
    {
        public static PuzzleNumberLocation GetPuzzleNumberLocationFromHorizontal(int[,] puzzle, int rowIndex, int[] emptySpaceColumnIndexes, int missingNumber)
        {
            PuzzleNumberLocation puzzleNumberLocation = new PuzzleNumberLocation { ColumnId = int.MinValue, RowId = int.MinValue, Value = int.MinValue };

            int columnIndex_ForMissingNumber = int.MinValue;
            int nrOfPossibleIndex_ForMissingNumber = 0;
            foreach (var columnIndex in from int columnIndex in emptySpaceColumnIndexes
                                        where !puzzle.ColumnAlreadyContainsNumber(columnIndex, missingNumber)
                                        select columnIndex)
            {
                nrOfPossibleIndex_ForMissingNumber++;
                columnIndex_ForMissingNumber = columnIndex;
            }

            if (nrOfPossibleIndex_ForMissingNumber == 1 && columnIndex_ForMissingNumber > int.MinValue)
            {
                puzzleNumberLocation.RowId = rowIndex;
                puzzleNumberLocation.ColumnId = columnIndex_ForMissingNumber;
                puzzleNumberLocation.Value = missingNumber;
            }

            if (puzzleNumberLocation.RowId == int.MinValue)
                return null;
            else
                return puzzleNumberLocation;
        }


        public static PuzzleNumberLocation GetPuzzleNumberLocationFromVertical(int[,] puzzle, int columnIndex, int[] emptySpaceRowIndexes, int missingNumber)
        {
            PuzzleNumberLocation puzzleNumberLocation = new PuzzleNumberLocation { ColumnId = int.MinValue, RowId = int.MinValue, Value = int.MinValue };

            int rowIndex_ForMissingNumber = int.MinValue;
            int nrOfPossibleIndex_ForMissingNumber = 0;

            foreach (var rowIndex in from int rowIndex in emptySpaceRowIndexes
                                     where !puzzle.RowAlreadyContainsNumber(rowIndex, missingNumber)
                                     select rowIndex)
            {
                nrOfPossibleIndex_ForMissingNumber++;
                rowIndex_ForMissingNumber = rowIndex;
            }
            if (nrOfPossibleIndex_ForMissingNumber == 1 && rowIndex_ForMissingNumber > int.MinValue)
            {
                puzzleNumberLocation.RowId = rowIndex_ForMissingNumber;
                puzzleNumberLocation.ColumnId = columnIndex;
                puzzleNumberLocation.Value = missingNumber;
            }

            if (puzzleNumberLocation.RowId == int.MinValue)
                return null;
            else
                return puzzleNumberLocation;
        }


        public static PuzzleNumberLocation GetPuzzleNumberLocationFromSquare(int[,] puzzle, int squareIndex, int[] emptySpaceSquareIndexes, int missingNumber)
        {
            PuzzleNumberLocation puzzleNumberLocation = new PuzzleNumberLocation { ColumnId = int.MinValue, RowId = int.MinValue, Value = int.MinValue };
            int columnIndex = int.MinValue;
            int rowIndex = int.MinValue;
            int nrOfPossibleIndex_ForMissingNumber = 0;
            foreach (int index in emptySpaceSquareIndexes)
            {
                columnIndex = GetColumnIndexFromSquareIndex(squareIndex, index);
                rowIndex = GetRowIndexFromSquareIndex(squareIndex, index);

                if (!puzzle.RowAlreadyContainsNumber(rowIndex, missingNumber))
                    nrOfPossibleIndex_ForMissingNumber++;
                if (!puzzle.ColumnAlreadyContainsNumber(columnIndex, missingNumber))
                    nrOfPossibleIndex_ForMissingNumber++;
            }
            if (nrOfPossibleIndex_ForMissingNumber == 2 && columnIndex > int.MinValue && rowIndex > int.MinValue)
            {
                puzzleNumberLocation.RowId = rowIndex;
                puzzleNumberLocation.ColumnId = columnIndex;
                puzzleNumberLocation.Value = missingNumber;
                puzzle.InsertPuzzleNumber(puzzleNumberLocation);
            }
            if (puzzleNumberLocation.RowId == int.MinValue)
                return null;
            else
                return puzzleNumberLocation;
        }


        public static int GetRowIndexFromSquareIndex(int squareIndex, int index)
        {
            //Works only with regular sudoku:
            //todo: Do this programatically. It is hardkoded for now:

            int rowIndex = int.MinValue;
            switch (squareIndex)
            {
                case 0:
                    switch (index)
                    {
                        case 0:
                        case 1:
                        case 2:
                            rowIndex = 0;
                            break;
                        case 3:
                        case 4:
                        case 5:
                            rowIndex = 1;
                            break;
                        case 6:
                        case 7:
                        case 8:
                            rowIndex = 2;
                            break;
                    }
                    break;
                case 1:
                    switch (index)
                    {
                        case 0:
                        case 1:
                        case 2:
                            rowIndex = 0;
                            break;
                        case 3:
                        case 4:
                        case 5:
                            rowIndex = 1;
                            break;
                        case 6:
                        case 7:
                        case 8:
                            rowIndex = 2;
                            break;
                    }
                    break;
                case 2:
                    switch (index)
                    {
                        case 0:
                        case 1:
                        case 2:
                            rowIndex = 0;
                            break;
                        case 3:
                        case 4:
                        case 5:
                            rowIndex = 1;
                            break;
                        case 6:
                        case 7:
                        case 8:
                            rowIndex = 2;
                            break;
                    }
                    break;
                case 3:
                    switch (index)
                    {
                        case 0:
                        case 1:
                        case 2:
                            rowIndex = 3;
                            break;
                        case 3:
                        case 4:
                        case 5:
                            rowIndex = 4;
                            break;
                        case 6:
                        case 7:
                        case 8:
                            rowIndex = 5;
                            break;
                    }
                    break;
                case 4:
                    switch (index)
                    {
                        case 0:
                        case 1:
                        case 2:
                            rowIndex = 3;
                            break;
                        case 3:
                        case 4:
                        case 5:
                            rowIndex = 4;
                            break;
                        case 6:
                        case 7:
                        case 8:
                            rowIndex = 5;
                            break;
                    }
                    break;
                case 5:
                    switch (index)
                    {
                        case 0:
                        case 1:
                        case 2:
                            rowIndex = 3;
                            break;
                        case 3:
                        case 4:
                        case 5:
                            rowIndex = 4;
                            break;
                        case 6:
                        case 7:
                        case 8:
                            rowIndex = 5;
                            break;
                    }
                    break;
                case 6:
                    switch (index)
                    {
                        case 0:
                        case 1:
                        case 2:
                            rowIndex = 6;
                            break;
                        case 3:
                        case 4:
                        case 5:
                            rowIndex = 7;
                            break;
                        case 6:
                        case 7:
                        case 8:
                            rowIndex = 8;
                            break;
                    }
                    break;
                case 7:
                    switch (index)
                    {
                        case 0:
                        case 1:
                        case 2:
                            rowIndex = 6;
                            break;
                        case 3:
                        case 4:
                        case 5:
                            rowIndex = 7;
                            break;
                        case 6:
                        case 7:
                        case 8:
                            rowIndex = 8;
                            break;
                    }
                    break;
                case 8:
                    switch (index)
                    {
                        case 0:
                        case 1:
                        case 2:
                            rowIndex = 6;
                            break;
                        case 3:
                        case 4:
                        case 5:
                            rowIndex = 7;
                            break;
                        case 6:
                        case 7:
                        case 8:
                            rowIndex = 8;
                            break;
                    }
                    break;


            }
            return rowIndex;
        }

        public static int GetColumnIndexFromSquareIndex(int squareIndex, int index)
        {
            int colIndex = int.MinValue;
            switch (squareIndex)
            {
                case 0:
                    switch (index)
                    {
                        case 0:
                        case 3:
                        case 6:
                            colIndex = 0;
                            break;
                        case 1:
                        case 4:
                        case 7:
                            colIndex = 1;
                            break;
                        case 2:
                        case 5:
                        case 8:
                            colIndex = 2;
                            break;
                    }
                    break;
                case 1:
                    switch (index)
                    {
                        case 0:
                        case 3:
                        case 6:
                            colIndex = 3;
                            break;
                        case 1:
                        case 4:
                        case 7:
                            colIndex = 4;
                            break;
                        case 2:
                        case 5:
                        case 8:
                            colIndex = 5;
                            break;
                    }
                    break;
                case 2:
                    switch (index)
                    {
                        case 0:
                        case 3:
                        case 6:
                            colIndex = 6;
                            break;
                        case 1:
                        case 4:
                        case 7:
                            colIndex = 7;
                            break;
                        case 2:
                        case 5:
                        case 8:
                            colIndex = 8;
                            break;
                    }
                    break;
                case 3:
                    switch (index)
                    {
                        case 0:
                        case 3:
                        case 6:
                            colIndex = 0;
                            break;
                        case 1:
                        case 4:
                        case 7:
                            colIndex = 1;
                            break;
                        case 2:
                        case 5:
                        case 8:
                            colIndex = 2;
                            break;
                    }
                    break;
                case 4:
                    switch (index)
                    {
                        case 0:
                        case 3:
                        case 6:
                            colIndex = 3;
                            break;
                        case 1:
                        case 4:
                        case 7:
                            colIndex = 4;
                            break;
                        case 2:
                        case 5:
                        case 8:
                            colIndex = 5;
                            break;
                    }
                    break;
                case 5:
                    switch (index)
                    {
                        case 0:
                        case 3:
                        case 6:
                            colIndex = 6;
                            break;
                        case 1:
                        case 4:
                        case 7:
                            colIndex = 7;
                            break;
                        case 2:
                        case 5:
                        case 8:
                            colIndex = 8;
                            break;
                    }
                    break;
                case 6:
                    switch (index)
                    {
                        case 0:
                        case 3:
                        case 6:
                            colIndex = 0;
                            break;
                        case 1:
                        case 4:
                        case 7:
                            colIndex = 1;
                            break;
                        case 2:
                        case 5:
                        case 8:
                            colIndex = 2;
                            break;
                    }
                    break;
                case 7:
                    switch (index)
                    {
                        case 0:
                        case 3:
                        case 6:
                            colIndex = 3;
                            break;
                        case 1:
                        case 4:
                        case 7:
                            colIndex = 4;
                            break;
                        case 2:
                        case 5:
                        case 8:
                            colIndex = 5;
                            break;
                    }
                    break;
                case 8:
                    switch (index)
                    {
                        case 0:
                        case 3:
                        case 6:
                            colIndex = 6;
                            break;
                        case 1:
                        case 4:
                        case 7:
                            colIndex = 7;
                            break;
                        case 2:
                        case 5:
                        case 8:
                            colIndex = 8;
                            break;
                    }
                    break;
            }
            return colIndex;
        }

        public static int[] GetEmptySpaceIndexInBulk(int[] row)
        {
            return row.Select((value, index) => new { value, index })
                    .Where(x => x.value == 0)
                    .Select(x => x.index)
                    .ToArray();
        }


        public static int[] GetMissingNumbersInBulk(int[] bulk)
        {
            return GetPossibleNumbers(bulk.Length).Except(bulk).ToArray();
        }

        public static int[] GetPossibleNumbers(int maxvalue)
        {
            return Enumerable.Range(1, maxvalue).ToArray();
        }

        public static int[] GetSquareFromPuzzle(int[,] puzzle, int squareIndex)
        {
            //Info: This works only with 9 sqaures (3x3)  (hardcoded for now)
            //Todo: Do this programatically:

            int[] square = new int[puzzle.NrOfSquares()];
            switch (squareIndex)
            {
                case 0:
                    square[0] = puzzle[0, 0];
                    square[1] = puzzle[0, 1];
                    square[2] = puzzle[0, 2];
                    square[3] = puzzle[1, 0];
                    square[4] = puzzle[1, 1];
                    square[5] = puzzle[1, 2];
                    square[6] = puzzle[2, 0];
                    square[7] = puzzle[2, 1];
                    square[8] = puzzle[2, 2];
                    break;
                case 1:
                    square[0] = puzzle[0, 3];
                    square[1] = puzzle[0, 4];
                    square[2] = puzzle[0, 5];
                    square[3] = puzzle[1, 3];
                    square[4] = puzzle[1, 4];
                    square[5] = puzzle[1, 5];
                    square[6] = puzzle[2, 3];
                    square[7] = puzzle[2, 4];
                    square[8] = puzzle[2, 5];
                    break;
                case 2:
                    square[0] = puzzle[0, 6];
                    square[1] = puzzle[0, 7];
                    square[2] = puzzle[0, 8];
                    square[3] = puzzle[1, 6];
                    square[4] = puzzle[1, 7];
                    square[5] = puzzle[1, 8];
                    square[6] = puzzle[2, 6];
                    square[7] = puzzle[2, 7];
                    square[8] = puzzle[2, 8];
                    break;
                case 3:
                    square[0] = puzzle[3, 0];
                    square[1] = puzzle[3, 1];
                    square[2] = puzzle[3, 2];
                    square[3] = puzzle[4, 0];
                    square[4] = puzzle[4, 1];
                    square[5] = puzzle[4, 2];
                    square[6] = puzzle[5, 0];
                    square[7] = puzzle[5, 1];
                    square[8] = puzzle[5, 2];
                    break;
                case 4:
                    square[0] = puzzle[3, 3];
                    square[1] = puzzle[3, 4];
                    square[2] = puzzle[3, 5];
                    square[3] = puzzle[4, 3];
                    square[4] = puzzle[4, 4];
                    square[5] = puzzle[4, 5];
                    square[6] = puzzle[5, 3];
                    square[7] = puzzle[5, 4];
                    square[8] = puzzle[5, 5];
                    break;
                case 5:
                    square[0] = puzzle[3, 6];
                    square[1] = puzzle[3, 7];
                    square[2] = puzzle[3, 8];
                    square[3] = puzzle[4, 6];
                    square[4] = puzzle[4, 7];
                    square[5] = puzzle[4, 8];
                    square[6] = puzzle[5, 6];
                    square[7] = puzzle[5, 7];
                    square[8] = puzzle[5, 8];
                    break;
                case 6:
                    square[0] = puzzle[6, 0];
                    square[1] = puzzle[6, 1];
                    square[2] = puzzle[6, 2];
                    square[3] = puzzle[7, 0];
                    square[4] = puzzle[7, 1];
                    square[5] = puzzle[7, 2];
                    square[6] = puzzle[8, 0];
                    square[7] = puzzle[8, 1];
                    square[8] = puzzle[8, 2];
                    break;
                case 7:
                    square[0] = puzzle[6, 3];
                    square[1] = puzzle[6, 4];
                    square[2] = puzzle[6, 5];
                    square[3] = puzzle[7, 3];
                    square[4] = puzzle[7, 4];
                    square[5] = puzzle[7, 5];
                    square[6] = puzzle[8, 3];
                    square[7] = puzzle[8, 4];
                    square[8] = puzzle[8, 5];
                    break;
                case 8:
                    square[0] = puzzle[6, 6];
                    square[1] = puzzle[6, 7];
                    square[2] = puzzle[6, 8];
                    square[3] = puzzle[7, 6];
                    square[4] = puzzle[7, 7];
                    square[5] = puzzle[7, 8];
                    square[6] = puzzle[8, 6];
                    square[7] = puzzle[8, 7];
                    square[8] = puzzle[8, 8];
                    break;
            }
            return square;
        }


        public static int[] GetRowFromPuzzle(int[,] puzzle, int rowIndex)
        {
            int[] row = new int[puzzle.NrOfColumns()];

            for (int colIndex = 0; colIndex < puzzle.NrOfColumns(); colIndex++)
                row[colIndex] = puzzle[rowIndex, colIndex];

            return row;
        }
        public static int[] GetColumnFromPuzzle(int[,] puzzle, int colIndex)
        {
            int[] column = new int[puzzle.NrOfRows()];

            for (int rowNr = 0; rowNr < puzzle.NrOfRows(); rowNr++)
                column[rowNr] = puzzle[rowNr, colIndex];

            return column;
        }
    }
}

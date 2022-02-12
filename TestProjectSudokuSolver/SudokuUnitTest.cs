using System;
using System.Collections.Generic;
using Xunit;
using SudokuLibrary.Extensions;
using FluentAssertions;
using SudokuLibrary.Models;
using SudokuLibrary;

namespace TestProjectSudokuSolver
{
    public class SudokuUnitTest
    {
        public int[,] SeedPuzzle()
        {
            return new int[9, 9] {
                {3,0,0,0,0,2,4,0,0 },
                {1,5,7,0,9,0,3,8,0 },
                {0,0,0,3,0,7,9,0,6 },

                {0,0,0,9,0,6,0,2,7 },
                {5,0,9,0,2,0,1,0,3 },
                {6,0,2,1,0,5,8,9,0 },

                {4,0,0,0,6,9,7,0,0 },
                {7,6,0,5,8,0,0,0,0 },
                {9,2,0,4,0,0,0,0,1 }
            };
        }

        [Fact]
        public void GetRowFromPuzzleTest()
        {
            int[] lstExpected = new int[] { 3, 0, 0, 0, 0, 2, 4, 0, 0 };

            int rowIndex = 0;

            int[,] puzzle = SeedPuzzle();

            int[] lstActual = PuzzleProcessor.GetRowFromPuzzle(puzzle, rowIndex);

            lstExpected.Should().BeEquivalentTo(lstActual);
        }
        [Fact]
        public void GetColumnFromPuzzleTest()
        {
            int[] lstExpected = new int[] { 0,5,0,0,0,0,0,6,2 };

            int colIndex = 1;

            int[,] puzzle = SeedPuzzle();

            int[] lstActual = PuzzleProcessor.GetColumnFromPuzzle(puzzle, colIndex);

            lstExpected.Should().BeEquivalentTo(lstActual);
        }
        [Fact]
        public void GetSquareFromPuzzle_ShouldBe_5_4_6_1_0_7_9_2_8()
        {
            int[] lstExpected = new int[] { 0,6,9,5,8,0,4,0,0 };
            int squareIndex = 7;
            int[,] puzzle = SeedPuzzle();
            int[] lstActual = PuzzleProcessor.GetSquareFromPuzzle(puzzle, squareIndex);

            lstExpected.Should().BeEquivalentTo(lstActual);
        }


        
        [Fact]
        public void GetMissingNumbersInBulkTest()
        {
            int[] expected = new int[] { 2, 4, 6 };
            int[] bulk = new int[] { 1, 5, 7, 0, 9, 0, 3, 8, 0 };

            int[] actual = PuzzleProcessor.GetMissingNumbersInBulk(bulk);

            expected.Should().BeEquivalentTo(actual);

        }
        [Fact]
        public void GetEmptySpaceIndexInBulkTest()
        {
            int[] expected = new int[] { 3, 5, 8 };
            int[] bulk = new int[] { 1, 5, 7, 0, 9, 0, 3, 8, 0 };

            int[] actual = PuzzleProcessor.GetEmptySpaceIndexInBulk(bulk);

            expected.Should().BeEquivalentTo(actual);
        }
        [Fact]
        public void ColumnAlreadyContainsNumberTestTrue()
        {
            int[,] puzzle = SeedPuzzle();
            Assert.True(puzzle.ColumnAlreadyContainsNumber(8, 6));
        }
        [Fact]
        public void ColumnAlreadyContainsNumberTestFalse()
        {
            int[,] puzzle = SeedPuzzle();
            Assert.False(puzzle.ColumnAlreadyContainsNumber(8, 2));
        }
        [Fact]
        public void RowAlreadyContainsNumberTestTrue()
        {
            int[,] puzzle = SeedPuzzle();
            Assert.True(puzzle.RowAlreadyContainsNumber(6, 7));
        }
        [Fact]
        public void RowAlreadyContainsNumberTestFalse()
        {
            int[,] puzzle = SeedPuzzle();
            Assert.False(puzzle.RowAlreadyContainsNumber(6, 3));
        }
        [Fact]
        public void GetRowIndexFromSquareIndexTest()
        {
            int[,] puzzle = SeedPuzzle();
            int squareIndex = 0;
            int index = 2;

            int expected = 0;
            int actual = PuzzleProcessor.GetRowIndexFromSquareIndex(squareIndex, index);
            Assert.Equal(expected,actual);

        }
        [Fact]
        public void GetRowIndexFromSquareIndexTest2()
        {
            int[,] puzzle = SeedPuzzle();
            int squareIndex = 5;
            int index = 6;

            int expected = 5;
            int actual = PuzzleProcessor.GetRowIndexFromSquareIndex(squareIndex, index);
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void GetColumnIndexFromSquareIndexTest()
        {
            int[,] puzzle = SeedPuzzle();
            int squareIndex = 0;
            int index = 2;

            int expected = 2;
            int actual = PuzzleProcessor.GetColumnIndexFromSquareIndex(squareIndex, index);
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void GetColumnIndexFromSquareIndexTest2()
        {
            int[,] puzzle = SeedPuzzle();
            int squareIndex = 4;
            int index = 5;

            int expected = 5;
            int actual = PuzzleProcessor.GetColumnIndexFromSquareIndex(squareIndex, index);
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void GetPuzzleNumberLocationHorizontalCheckTest()
        {
            int[,] puzzle = SeedPuzzle();
            int rowIndex = 1;
            int[] emptySpaceColumnIndexes = new []{ 3, 5, 8 };
            int missingNumber = 6;

            PuzzleNumberLocation expected = new PuzzleNumberLocation { ColumnId = 3, RowId = 1, Value=6 };    
            PuzzleNumberLocation actual = PuzzleProcessor.GetPuzzleNumberLocationFromHorizontal(puzzle, rowIndex, emptySpaceColumnIndexes,  missingNumber);
            expected.Should().BeEquivalentTo(actual);
        }
        [Fact]
        public void GetPuzzleNumberLocationVerticalCheckTest()
        {
            int[,] puzzle = SeedPuzzle();
            int columnIndex = 0;
            int[] emptySpaceRowIndexes = new[] { 3 };
            int missingNumber = 8;

            PuzzleNumberLocation expected = new PuzzleNumberLocation { ColumnId = 0, RowId = 3, Value = 8 };
            PuzzleNumberLocation actual = PuzzleProcessor.GetPuzzleNumberLocationFromVertical(puzzle, columnIndex, emptySpaceRowIndexes, missingNumber);
            expected.Should().BeEquivalentTo(actual);
        }
        [Fact]
        public void GetPossibleNumbersTest()
        {
            int[] expected = new[] { 1,2,3,4,5 };
            int[] bulk = new[] { 0, 6, 0, 5, 0 };
            int[] actual = PuzzleProcessor.GetPossibleNumbers(bulk.Length);

            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void GetPossibleNumbersShouldBeEmpty()
        {
            int[] expected = new int[0];
            int[] bulk = new int[0];
            int[] actual = PuzzleProcessor.GetPossibleNumbers(bulk.Length);

            Assert.Equal(expected, actual);
        }
        

        [Fact]
        public void NumberOfMissingTest()
        {
            int[,] puzzle = SeedPuzzle();

            int expected = 41;
            int actual = puzzle.NumberOfMissing();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void NrOfSquaresTest()
        {
            int[,] puzzle = SeedPuzzle();
            int expected = 9;
            int actual = puzzle.NrOfSquares();
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void InsertPuzzleNumberShouldWork()
        {
            int[,] puzzle = SeedPuzzle();
            int expected = 2;
            PuzzleNumberLocation puzzleNumberLocation= new PuzzleNumberLocation { RowId = 0, ColumnId = 1,Value = 2 };
            puzzle.InsertPuzzleNumber(puzzleNumberLocation);
            int actual = puzzle[0, 1];

            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(-1,1,1, "RowId")]
        [InlineData(99,1,1, "RowId")]
        [InlineData(0,-1,1,"ColumnId")]
        [InlineData(0,99,1,"ColumnId")]
        [InlineData(1,1,-1, "Value")]
        [InlineData(1,1,99, "Value")]
        public void InsertPuzzleNumberShouldFail(int rowId, int columnId, int value, string param)
        {
            int[,] puzzle = SeedPuzzle();
            PuzzleNumberLocation puzzleNumberLocation = new PuzzleNumberLocation { RowId = rowId, ColumnId = columnId, Value = value };

            Assert.Throws<ArgumentException>(param, ()=> puzzle.InsertPuzzleNumber(puzzleNumberLocation));

        }
        

    }
    
}

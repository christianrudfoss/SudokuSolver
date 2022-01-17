using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public class PuzzleNumberLocation
    {
        public int RowId { get; set; }
        public int ColumnId { get; set; }
        public int Value { get; set; }
    }
}

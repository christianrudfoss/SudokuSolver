using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public class PossibleNumber
    {
        public int Number { get; set; }
        public bool Taken { get; set; }
    }
}

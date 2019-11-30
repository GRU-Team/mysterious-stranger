using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteriousStranger
{
    internal sealed class Cell
    {
        internal int X { get; set; }
        internal int Y { get; set; }
        internal CellType Type { get; set; }
        internal string Message { get; set; }

        internal Cell(int x, int y, CellType type, string message)
        {
            this.X = x;
            this.Y = y;
            this.Type = type;
            this.Message = message;
        }
    }
}

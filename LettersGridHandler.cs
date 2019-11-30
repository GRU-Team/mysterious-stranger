using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteriousStranger
{
    internal class LettersGridHandler
    {
        internal int sizeOfGrid;
        internal int[,] grid;
        internal int currentPosition;
        internal LettersGridHandler(int sizeOfGrid)
        {
            this.sizeOfGrid = sizeOfGrid;
            grid = new int[this.sizeOfGrid, this.sizeOfGrid];
        }

       

    }
}

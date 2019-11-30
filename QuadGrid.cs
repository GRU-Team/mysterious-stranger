using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteriousStranger
{
    internal sealed class QuadGrid
    {
        internal List<List<Cell>> Grid { get; set; }
        internal int SizeOfGridSide { get; set; }
        internal QuadGrid(int sizeOfGridSide)
        {
            this.SizeOfGridSide = sizeOfGridSide;
            this.Grid = new List<List<Cell> > (sizeOfGridSide);

            InitGridWithRandomCells();
        }

        private void InitGridWithZeroCells()
        {
            for(int i = 0; i < SizeOfGridSide; i++)
            {
                Grid.Add(new List<Cell>());
                for (int j = 0; j < SizeOfGridSide; j++)
                {
                    Grid.ElementAt(i).Add(new Cell(i, j, CellType.Empty, ""));
                }
            }
        }

        private void InitGridWithRandomCells()
        {
            Random rnd = new Random();
            for (int i = 0; i < SizeOfGridSide; i++)
            {
                Grid.Add(new List<Cell>());
                for (int j = 0; j < SizeOfGridSide; j++)
                {
                    Array values = Enum.GetValues(typeof(CellType));
                    var cellType = (CellType)values.GetValue(rnd.Next(values.Length));
                    Grid.ElementAt(i).Add(new Cell(i, j, cellType, ""));
                }
            }

        }

        internal void AsignValueAtPosition(int x, int y, Cell value)
        {
            //Lol, it's works
            Grid.ElementAt(x).Insert(y, value);
        }

        internal Cell GetCellAtPosition(int x, int y)
        {
            return Grid.ElementAt(x).ElementAt(y);
        }
    }
}

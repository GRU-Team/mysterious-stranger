using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteriousStranger
{
    internal class LettersGridHandler
    {
        static internal ulong MessageId { get; set; }
        static internal IUserMessage MessageWithGrid { get; set; }
        static internal QuadGrid Grid;
        static internal int currentXPosition;
        static internal int currentYPosition;
        static internal void Init(int sizeOfGrid)
        {
            Grid = new QuadGrid(sizeOfGrid);
        }

        static internal void Move() { }
        static internal void Update() { }

        static internal string GetGridInString()
        {
            string result = string.Empty;
            for (int i = 0; i < Grid.SizeOfGridSide; i++)
            {
                for (int j = 0; j < Grid.SizeOfGridSide; j++)
                {
                    var cell = Grid.GetCellAtPosition(i, j);
                    if (cell.Type == CellType.Empty)
                    {
                        result += "░";
                    }
                    else
                    {
                        result += "▓";
                    }
                }
                result += Environment.NewLine;
            }

            return result;
        }
    }
}

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
        static internal IUserMessage MessageWithGrid { get; set; }
        static internal QuadGrid gridOfLetters;
        static internal PlayerData playerData;
        static internal void Init(int sizeOfGrid)
        {
            Random rnd = new Random();
            gridOfLetters = new QuadGrid(sizeOfGrid);
            playerData = new PlayerData(rnd.Next(0, sizeOfGrid-1), rnd.Next(0, sizeOfGrid-1), 1);
        }

        static internal void WriteMessage(string message)
        {
            var cell = gridOfLetters.GetCellAtPosition(playerData.Y, playerData.X);
            if(cell.Type == CellType.Filled)
            {
                return;
            }
            cell.Message = message;
            cell.Type = CellType.Filled;
        }
        static internal string ReadMessage()
        {
            var cell = gridOfLetters.GetCellAtPosition(playerData.Y, playerData.X);
            if (cell.Type != CellType.Empty)
            {
                return cell.Message;
            }
            return "Никто ещё не оставил записи здесь...";
        }
        static internal void MoveRight()
        {
            playerData.X += 1;
            Console.WriteLine($"Player.X {playerData.X}");
            if (playerData.X > gridOfLetters.SizeOfGridSide - 1)
            {
                playerData.X = 0;
            }
        }
        static internal void MoveLeft()
        {
            playerData.X -= 1;
            Console.WriteLine($"Player.X {playerData.X}");
            if (playerData.X < 0)
            {
                playerData.X = gridOfLetters.SizeOfGridSide - 1;
            }
        }
        static internal void MoveDown()
        {
            playerData.Y += 1;
            Console.WriteLine($"Player.Y {playerData.Y}");
            if (playerData.Y > gridOfLetters.SizeOfGridSide - 1)
            {
                playerData.Y = 0;
            }
        }
        static internal void MoveUp()
        {
            playerData.Y -= 1;
            Console.WriteLine($"Player.Y {playerData.Y}"); 
            if (playerData.Y < 0)
            {
                playerData.Y = gridOfLetters.SizeOfGridSide - 1;
            }
        }
        static internal string GetGridInString()
        {
            string result = string.Empty;
            for (int i = 0; i < gridOfLetters.SizeOfGridSide; i++)
            {
                for (int j = 0; j < gridOfLetters.SizeOfGridSide; j++)
                {
                    var cell = gridOfLetters.GetCellAtPosition(i, j);
                    result += DrawCell(cell, i, j);
                }
                result += Environment.NewLine;
            }

            return result;
        }

        static private string DrawCell(Cell cell, int x, int y)
        {
            if(PlayerOnThisPosition(x, y))
            {
                return SymbolMap.PlayerCell;
            }
            switch(cell.Type)
            {
                case CellType.Empty:
                    return SymbolMap.EmptyCell;
                case CellType.Filled:
                    return SymbolMap.FilledCell;
                default:
                    return SymbolMap.UnknowCell;
            }
        }

        private static bool PlayerOnThisPosition(int x, int y)
        {
            if(playerData.X == y && playerData.Y == x)
            {
                return true;
            }
            return false;
        }
    }
}

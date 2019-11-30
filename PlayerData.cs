using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteriousStranger
{
    internal class PlayerData
    {
        internal int Y;
        internal int X;
        internal int countOfAvailableMessages;

        public PlayerData(int currentX, int currentY, int countOfAvailableMessages)
        {
            this.Y = currentX;
            this.X = currentY;
            this.countOfAvailableMessages = countOfAvailableMessages;
        }
    }
}

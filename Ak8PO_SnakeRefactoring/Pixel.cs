using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak8PO_SnakeRefactoring
{
    public class Pixel
    {
        public Pixel(int xPos, int yPos, ConsoleColor screenColor)
        {
            XPos = xPos;
            YPos = yPos;
            ScreenColor = screenColor;
        }

        public int XPos { get; set; }
        public int YPos { get; set; }
        public ConsoleColor ScreenColor { get; set; }
    }
}

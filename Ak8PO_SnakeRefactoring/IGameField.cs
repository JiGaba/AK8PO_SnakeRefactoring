using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak8PO_SnakeRefactoring
{
    public interface IGameField
    {
        void ClearField(int screenwidth, int screenheight);
        void DrawFrame(int screenWidth, int screenHeight);
        void DrawPixel(Pixel pixel);
        void GameOverMessage(int screenHeight, int screenWidth, int score);
    }
}

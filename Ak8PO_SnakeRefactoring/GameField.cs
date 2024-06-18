using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak8PO_SnakeRefactoring
{
    public class GameField : IGameField
    {
        public const string _square = "■";

        public GameField(int screenHeight, int screenWidth) 
        {
            Console.WindowHeight = screenHeight;
            Console.WindowWidth = screenWidth;
        }

        public void ClearField(int screenwidth, int screenheight)
        {
            var blackLine = string.Join("", new byte[screenwidth - 2].Select(b => " ").ToArray());
            Console.ForegroundColor = ConsoleColor.Black;

            for (int i = 1; i < screenheight - 1; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write(blackLine);
            }
        }

        public void DrawFrame(int screenWidth, int screenHeight)
        {
            DrawHorizontalBar(screenWidth, screenHeight);

            for (int i = 0; i < screenHeight; i++)
            {
                DrawPixel(new Pixel(0, i, ConsoleColor.DarkGray));
                DrawPixel(new Pixel(screenWidth - 1, i, ConsoleColor.DarkGray));
            }
        }

        public void DrawPixel(Pixel pixel)
        {
            Console.SetCursorPosition(pixel.XPos, pixel.YPos);
            Console.ForegroundColor = pixel.ScreenColor;
            Console.Write(_square);
        }

        public void GameOverMessage(int screenHeight, int screenWidth, int score)
        {
            Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
            Console.WriteLine("Game over, Score: {0}", score);
            Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
        }

        private void DrawHorizontalBar(int screenWidth, int screenHeight)
        {
            var horizontalBar = string.Join("", new byte[screenWidth].Select(b => _square).ToArray());

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(0, 0);
            Console.Write(horizontalBar);
            Console.SetCursorPosition(0, screenHeight - 1);
            Console.Write(horizontalBar);
        }
    }
}

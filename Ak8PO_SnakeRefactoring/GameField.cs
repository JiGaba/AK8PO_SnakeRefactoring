using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak8PO_SnakeRefactoring
{
    public class GameField
    {
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

        public void DrawFrame(int screenwidth, int screenheight)
        {
            var horizontalBar = string.Join("", new byte[screenwidth].Select(b => "■").ToArray());

            Console.SetCursorPosition(0, 0);
            Console.Write(horizontalBar);
            Console.SetCursorPosition(0, screenheight - 1);
            Console.Write(horizontalBar);

            for (int i = 0; i < screenheight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(screenwidth - 1, i);
                Console.Write("■");
            }
        }

        public void GameOverMessage(int screenHeight, int screenWidth, int score)
        {
            Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
            Console.WriteLine("Game over, Score: {0}", score);
            Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
        }
    }
}

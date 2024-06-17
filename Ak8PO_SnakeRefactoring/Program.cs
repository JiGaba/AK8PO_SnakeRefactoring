using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak8PO_SnakeRefactoring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 16;
            Console.WindowWidth = 32;
            int screenwidth = Console.WindowWidth;
            int screenheight = Console.WindowHeight;
            Random randomnummer = new Random();
            int score = 5;
            bool gameOver = false;
            Pixel hoofd = new Pixel(screenwidth / 2, screenheight / 2, ConsoleColor.Red);
            Direction movement = Direction.Right;
            List<int> xposlijf = new List<int>();
            List<int> yposlijf = new List<int>();
            int berryx = randomnummer.Next(0, screenwidth);
            int berryy = randomnummer.Next(0, screenheight);
            DateTime timeMainLoop;
            DateTime timeByKeyLoop;
            ButtonPressed buttonPressed;

            DrawBorder(screenwidth, screenheight);

            while (true)
            {
                ClearConsole(screenwidth, screenheight);
                if (hoofd.XPos == screenwidth - 1 || hoofd.XPos == 0 || hoofd.YPos == screenheight - 1 || hoofd.YPos == 0)
                {
                    gameOver = true;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                if (berryx == hoofd.XPos && berryy == hoofd.YPos)
                {
                    score++;
                    berryx = randomnummer.Next(1, screenwidth - 2);
                    berryy = randomnummer.Next(1, screenheight - 2);
                }
                for (int i = 0; i < xposlijf.Count(); i++)
                {
                    Console.SetCursorPosition(xposlijf[i], yposlijf[i]);
                    Console.Write("■");

                    if (xposlijf[i] == hoofd.XPos && yposlijf[i] == hoofd.YPos)
                    {
                        gameOver = true;
                    }
                }
                if (gameOver) break;
                
                Console.SetCursorPosition(hoofd.XPos, hoofd.YPos);
                Console.ForegroundColor = hoofd.ScreenColor;
                Console.Write("■");
                Console.SetCursorPosition(berryx, berryy);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("■");
                timeMainLoop = DateTime.Now;
                buttonPressed = ButtonPressed.No;
                while (true)
                {
                    timeByKeyLoop = DateTime.Now;
                    if (timeByKeyLoop.Subtract(timeMainLoop).TotalMilliseconds > 500) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo toets = Console.ReadKey(true);
                        if (toets.Key.Equals(ConsoleKey.UpArrow) && movement != Direction.Down && buttonPressed == ButtonPressed.No)
                        {
                            movement = Direction.Up;
                            buttonPressed = ButtonPressed.Yes;
                        }
                        if (toets.Key.Equals(ConsoleKey.DownArrow) && movement != Direction.Up && buttonPressed == ButtonPressed.No)
                        {
                            movement = Direction.Down;
                            buttonPressed = ButtonPressed.Yes;
                        }
                        if (toets.Key.Equals(ConsoleKey.LeftArrow) && movement != Direction.Right && buttonPressed == ButtonPressed.No)
                        {
                            movement = Direction.Left;
                            buttonPressed = ButtonPressed.Yes;
                        }
                        if (toets.Key.Equals(ConsoleKey.RightArrow) && movement != Direction.Left && buttonPressed == ButtonPressed.No)
                        {
                            movement = Direction.Right;
                            buttonPressed = ButtonPressed.Yes;
                        }
                    }
                }
                xposlijf.Add(hoofd.XPos);
                yposlijf.Add(hoofd.YPos);
                switch (movement)
                {
                    case Direction.Up:
                        hoofd.YPos--;
                        break;
                    case Direction.Down:
                        hoofd.YPos++;
                        break;
                    case Direction.Left:
                        hoofd.XPos--;
                        break;
                    case Direction.Right:
                        hoofd.XPos++;
                        break;
                }
                if (xposlijf.Count() > score)
                {
                    xposlijf.RemoveAt(0);
                    yposlijf.RemoveAt(0);
                }
            }
            Console.SetCursorPosition(screenwidth / 5, screenheight / 2);
            Console.WriteLine("Game over, Score: " + score);
            Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);
        }

        private static void ClearConsole(int screenwidth, int screenheight)
        {
            var blackLine = string.Join("", new byte[screenwidth - 2].Select(b => " ").ToArray());
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 1; i < screenheight - 1; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write(blackLine);
            }
        }

        private static void DrawBorder(int screenwidth, int screenheight)
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

    }
}

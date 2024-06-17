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
            int gameover = 0;
            Pixel hoofd = new Pixel(screenwidth / 2, screenheight / 2, ConsoleColor.Red);
            //hoofd.xpos = screenwidth / 2;
            //hoofd.ypos = screenheight / 2;
            //hoofd.schermkleur = ConsoleColor.Red;
            //string movement = "RIGHT";
            Direction movement = Direction.Right;
            List<int> xposlijf = new List<int>();
            List<int> yposlijf = new List<int>();
            int berryx = randomnummer.Next(0, screenwidth);
            int berryy = randomnummer.Next(0, screenheight);
            DateTime tijd;// = DateTime.Now;
            DateTime tijd2;// = DateTime.Now;
            string buttonpressed = "no";
            while (true)
            {
                Console.Clear();
                if (hoofd.XPos == screenwidth - 1 || hoofd.XPos == 0 || hoofd.YPos == screenheight - 1 || hoofd.YPos == 0)
                {
                    gameover = 1;
                }
                for (int i = 0; i < screenwidth; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("■");
                }
                for (int i = 0; i < screenwidth; i++)
                {
                    Console.SetCursorPosition(i, screenheight - 1);
                    Console.Write("■");
                }
                for (int i = 0; i < screenheight; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("■");
                }
                for (int i = 0; i < screenheight; i++)
                {
                    Console.SetCursorPosition(screenwidth - 1, i);
                    Console.Write("■");
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
                        gameover = 1;
                    }
                }
                if (gameover == 1)
                {
                    break;
                }
                Console.SetCursorPosition(hoofd.XPos, hoofd.YPos);
                Console.ForegroundColor = hoofd.ScreenColor;
                Console.Write("■");
                Console.SetCursorPosition(berryx, berryy);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("■");
                tijd = DateTime.Now;
                buttonpressed = "no";
                while (true)
                {
                    tijd2 = DateTime.Now;
                    if (tijd2.Subtract(tijd).TotalMilliseconds > 500) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo toets = Console.ReadKey(true);
                        if (toets.Key.Equals(ConsoleKey.UpArrow) && movement != Direction.Down && buttonpressed == "no")
                        {
                            movement = Direction.Up;
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.DownArrow) && movement != Direction.Up && buttonpressed == "no")
                        {
                            movement = Direction.Down;
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.LeftArrow) && movement != Direction.Right && buttonpressed == "no")
                        {
                            movement = Direction.Left;
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.RightArrow) && movement != Direction.Left && buttonpressed == "no")
                        {
                            movement = Direction.Right;
                            buttonpressed = "yes";
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
    }
}

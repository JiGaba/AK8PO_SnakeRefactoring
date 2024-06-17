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
            bool gameover = false;
            Pixel hoofd = new Pixel(screenwidth / 2, screenheight / 2, ConsoleColor.Red);
            //hoofd.xpos = screenwidth / 2;
            //hoofd.ypos = screenheight / 2;
            //hoofd.schermkleur = ConsoleColor.Red;
            //string movement = "RIGHT";
            DirectionEnum movement = DirectionEnum.Right;
            List<int> xposlijf = new List<int>();
            List<int> yposlijf = new List<int>();
            int berryx = randomnummer.Next(0, screenwidth);
            int berryy = randomnummer.Next(0, screenheight);
            DateTime tijd;// = DateTime.Now;
            DateTime tijd2;// = DateTime.Now;
            ButtonPressedEnum buttonPressed;// = ButtonPressedEnum.No;
            while (true)
            {
                Console.Clear();
                if (hoofd.XPos == screenwidth - 1 || hoofd.XPos == 0 || hoofd.YPos == screenheight - 1 || hoofd.YPos == 0)
                {
                    gameover = true;
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
                        gameover = true;
                    }
                }
                if (gameover)
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
                buttonPressed = ButtonPressedEnum.No;
                while (true)
                {
                    tijd2 = DateTime.Now;
                    if (tijd2.Subtract(tijd).TotalMilliseconds > 500) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo toets = Console.ReadKey(true);
                        if (toets.Key.Equals(ConsoleKey.UpArrow) && movement != DirectionEnum.Down && buttonPressed == ButtonPressedEnum.No)
                        {
                            movement = DirectionEnum.Up;
                            buttonPressed = ButtonPressedEnum.Yes;
                        }
                        if (toets.Key.Equals(ConsoleKey.DownArrow) && movement != DirectionEnum.Up && buttonPressed == ButtonPressedEnum.No)
                        {
                            movement = DirectionEnum.Down;
                            buttonPressed = ButtonPressedEnum.Yes;
                        }
                        if (toets.Key.Equals(ConsoleKey.LeftArrow) && movement != DirectionEnum.Right && buttonPressed == ButtonPressedEnum.No)
                        {
                            movement = DirectionEnum.Left;
                            buttonPressed = ButtonPressedEnum.Yes;
                        }
                        if (toets.Key.Equals(ConsoleKey.RightArrow) && movement != DirectionEnum.Left && buttonPressed == ButtonPressedEnum.No)
                        {
                            movement = DirectionEnum.Right;
                            buttonPressed = ButtonPressedEnum.Yes;
                        }
                    }
                }
                xposlijf.Add(hoofd.XPos);
                yposlijf.Add(hoofd.YPos);
                switch (movement)
                {
                    case DirectionEnum.Up:
                        hoofd.YPos--;
                        break;
                    case DirectionEnum.Down:
                        hoofd.YPos++;
                        break;
                    case DirectionEnum.Left:
                        hoofd.XPos--;
                        break;
                    case DirectionEnum.Right:
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak8PO_SnakeRefactoring
{
    public class GameEngine
    {
        private const int _screenHeight = 16;
        private const int _screenWidth = 32;

        private readonly GameField _gameField;
        private readonly Random _randomGen;

        private DateTime _timeMainLoop;
        private DateTime _timeByKeyLoop;
        private ButtonPressed _buttonPressed;
        private Direction _movement;
        private int _score;
        private bool _gameOver;  

        public GameEngine() 
        {
            _gameField = new GameField(_screenHeight, _screenWidth); 
            _randomGen = new Random();
            _score = 5;
            _gameOver = false;
            _movement = Direction.Right;
        }

        public void Run()
        {
            Pixel hoofd = new Pixel(_screenWidth / 2, _screenHeight / 2, ConsoleColor.Red);
            
            List<int> xposlijf = new List<int>();
            List<int> yposlijf = new List<int>();
            int berryx = _randomGen.Next(0, _screenWidth);
            int berryy = _randomGen.Next(0, _screenHeight);
            

            _gameField.DrawFrame(_screenWidth, _screenHeight);

            while (true)
            {
                _gameField.ClearField(_screenWidth, _screenHeight);
                if (hoofd.XPos == _screenWidth - 1 || hoofd.XPos == 0 || hoofd.YPos == _screenHeight - 1 || hoofd.YPos == 0)
                {
                    _gameOver = true;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                if (berryx == hoofd.XPos && berryy == hoofd.YPos)
                {
                    _score++;
                    berryx = _randomGen.Next(1, _screenWidth - 2);
                    berryy = _randomGen.Next(1, _screenHeight - 2);
                }
                for (int i = 0; i < xposlijf.Count(); i++)
                {
                    Console.SetCursorPosition(xposlijf[i], yposlijf[i]);
                    Console.Write("■");

                    if (xposlijf[i] == hoofd.XPos && yposlijf[i] == hoofd.YPos)
                    {
                        _gameOver = true;
                    }
                }
                if (_gameOver) break;

                Console.SetCursorPosition(hoofd.XPos, hoofd.YPos);
                Console.ForegroundColor = hoofd.ScreenColor;
                Console.Write("■");
                Console.SetCursorPosition(berryx, berryy);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("■");
                _timeMainLoop = DateTime.Now;
                _buttonPressed = ButtonPressed.No;
                while (true)
                {
                    _timeByKeyLoop = DateTime.Now;
                    if (_timeByKeyLoop.Subtract(_timeMainLoop).TotalMilliseconds > 500) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo toets = Console.ReadKey(true);
                        if (toets.Key.Equals(ConsoleKey.UpArrow) && _movement != Direction.Down && _buttonPressed == ButtonPressed.No)
                        {
                            _movement = Direction.Up;
                            _buttonPressed = ButtonPressed.Yes;
                        }
                        if (toets.Key.Equals(ConsoleKey.DownArrow) && _movement != Direction.Up && _buttonPressed == ButtonPressed.No)
                        {
                            _movement = Direction.Down;
                            _buttonPressed = ButtonPressed.Yes;
                        }
                        if (toets.Key.Equals(ConsoleKey.LeftArrow) && _movement != Direction.Right && _buttonPressed == ButtonPressed.No)
                        {
                            _movement = Direction.Left;
                            _buttonPressed = ButtonPressed.Yes;
                        }
                        if (toets.Key.Equals(ConsoleKey.RightArrow) && _movement != Direction.Left && _buttonPressed == ButtonPressed.No)
                        {
                            _movement = Direction.Right;
                            _buttonPressed = ButtonPressed.Yes;
                        }
                    }
                }
                xposlijf.Add(hoofd.XPos);
                yposlijf.Add(hoofd.YPos);
                switch (_movement)
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
                if (xposlijf.Count() > _score)
                {
                    xposlijf.RemoveAt(0);
                    yposlijf.RemoveAt(0);
                }
            }
        }
    }
}

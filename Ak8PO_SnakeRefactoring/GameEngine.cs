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
        private readonly GameTimer _gameTimer;
        private readonly Snake _snake;

        private ButtonPressed _buttonPressed;
        private Direction _movement;
        private int _score;
        private bool _gameOver;  

        public GameEngine() 
        {
            _score = 5;
            _gameOver = false;
            _movement = Direction.Right;

            _gameField = new GameField(_screenHeight, _screenWidth); 
            _gameTimer = new GameTimer();
            _randomGen = new Random();
            _snake = new Snake(_score, _screenWidth, _screenHeight);
        }

        public void Run()
        {
            //Point snakeHead = new Point(_screenWidth / 2, _screenHeight / 2, ConsoleColor.Red);
            
            //List<int> xposlijf = new List<int>();
            //List<int> yposlijf = new List<int>();
            int berryx = _randomGen.Next(1, _screenWidth-1);
            int berryy = _randomGen.Next(1, _screenHeight-1);
            

            _gameField.DrawFrame(_screenWidth, _screenHeight);

            while (true)
            {
                _gameField.ClearField(_screenWidth, _screenHeight);

                if (_snake.Head.XPos == _screenWidth - 1 || _snake.Head.XPos == 0 || _snake.Head.YPos == _screenHeight - 1 || _snake.Head.YPos == 0)
                {
                    _gameOver = true;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                if (berryx == _snake.Head.XPos && berryy == _snake.Head.YPos)
                {
                    _score++;
                    _snake.IncreaseLength();
                    berryx = _randomGen.Next(1, _screenWidth - 2);
                    berryy = _randomGen.Next(1, _screenHeight - 2);
                }
                //for (int i = 0; i < xposlijf.Count(); i++)
                for (int i = 0; i < _snake.Length(); i++)
                {
                    //Console.SetCursorPosition(xposlijf[i], yposlijf[i]);
                    Console.SetCursorPosition(_snake.Body[i].XPos, _snake.Body[i].YPos);
                    Console.Write("■");

                    //if (xposlijf[i] == snakeHead.XPos && yposlijf[i] == snakeHead.YPos)
                    if (_snake.Body[i].XPos == _snake.Head.XPos && _snake.Body[i].YPos == _snake.Head.YPos)
                    {
                        _gameOver = true;
                    }
                }
                if (_gameOver) break;

                Console.SetCursorPosition(_snake.Head.XPos, _snake.Head.YPos);
                Console.ForegroundColor = _snake.Head.ScreenColor;
                Console.Write("■");
                Console.SetCursorPosition(berryx, berryy);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("■");
                
                _gameTimer.MainLoopReset();
                _buttonPressed = ButtonPressed.No;
                while (true)
                {
                    _gameTimer.KeyLoopReset();
                    if (_gameTimer.TimeExpired()) { break; }
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
                _snake.Add(_snake.Head);
                //yposlijf.Add(snakeHead.YPos);

                _snake.Move(_movement);
                /*

                // remove tail
                if (_snake.Length() > _score)
                {
                    _snake.Body.RemoveAt(0);
                    //yposlijf.RemoveAt(0);
                }
                */
            }

            _gameField.GameOverMessage(_screenHeight, _screenWidth, _score);
        }

        
    }
}

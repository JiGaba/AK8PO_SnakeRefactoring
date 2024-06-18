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
        private readonly GameTimer _gameTimer;
        private readonly Snake _snake;
        private readonly Food _food;

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
            _gameField.DrawFrame(_screenWidth, _screenHeight);
            _gameTimer = new GameTimer();
            _snake = new Snake(_score, _screenWidth, _screenHeight);
            _food = new Food(_screenWidth, _screenHeight);
        }

        public void Run()
        {
            while (true)
            {
                _gameField.ClearField(_screenWidth, _screenHeight);

                if (_snake.IsCrashInto()) _gameOver = true;
                if (_snake.IsFoodEaten(_food.Position)) FoodIsEaten();
                ShowSnakePosition();
                if (_gameOver) break;

                _gameField.DrawPixel(_snake.Head);
                _gameField.DrawPixel(_food.Position);
                
                ReadKeyLoop();

                _snake.Increase();
                _snake.Move(_movement);
            }

            _gameField.GameOverMessage(_screenHeight, _screenWidth, _score);
        }
        private void FoodIsEaten()
        {
            _score++;
            _snake.IncreaseLength();
            _food.NextPosition();
        }
        private void ShowSnakePosition()
        {
            for (int i = 0; i < _snake.Length(); i++)
            {
                _gameField.DrawPixel(_snake.Body[i]);

                if (_snake.IsBitHimself(i)) _gameOver = true;
            }
        }

        private void ReadKeyLoop()
        {
            _gameTimer.MainLoopReset();
            _buttonPressed = ButtonPressed.No;

            while (true)
            {
                _gameTimer.KeyLoopReset();
                if (_gameTimer.TimeExpired()) break;

                ReadKey();
            }
        }

        private void ReadKey()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key.Equals(ConsoleKey.UpArrow) && _movement != Direction.Down && _buttonPressed == ButtonPressed.No)
                {
                    SetupDirection(Direction.Up);
                }
                if (key.Key.Equals(ConsoleKey.DownArrow) && _movement != Direction.Up && _buttonPressed == ButtonPressed.No)
                {
                    SetupDirection(Direction.Down);
                }
                if (key.Key.Equals(ConsoleKey.LeftArrow) && _movement != Direction.Right && _buttonPressed == ButtonPressed.No)
                {
                    SetupDirection(Direction.Left);
                }
                if (key.Key.Equals(ConsoleKey.RightArrow) && _movement != Direction.Left && _buttonPressed == ButtonPressed.No)
                {
                    SetupDirection(Direction.Right);
                }
            }
        }

        private void SetupDirection(Direction direction) 
        {
            _movement = direction;
            _buttonPressed = ButtonPressed.Yes;
        }
    }
}

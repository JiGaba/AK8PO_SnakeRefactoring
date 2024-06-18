using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak8PO_SnakeRefactoring
{
    public class Food : IFood
    {
        public Pixel Position { get; set; }

        private readonly Random _randomGenerator;
        private int _screenHeight;
        private int _screenWidth;

        public Food(int screenWidth, int screenHeight)
        {
            _screenHeight = screenHeight;
            _screenWidth = screenWidth;
            _randomGenerator = new Random();

            NextPosition();
        }

        public void NextPosition()
        {
            Position = new Pixel(
                _randomGenerator.Next(1, _screenWidth - 2), 
                _randomGenerator.Next(1, _screenHeight - 2),
                ConsoleColor.Cyan);
        }
    }
}

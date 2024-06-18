using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak8PO_SnakeRefactoring
{
    public class Snake
    {
        public Pixel Head { get; set; }
        public List<Pixel> Body { get; set; }
        private int _length;
        private int _screenWidth;
        private int _screenHeight;

        public Snake(int initLength, int screenWidth, int screenHeight) 
        { 
            _length = initLength;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;   
            Body = new List<Pixel>();
            Head = new Pixel(screenWidth / 2, screenHeight / 2, ConsoleColor.Red);
        }
        public void IncreaseLength()
        {
            _length++;
        }
        public int Length()
        {
            return Body.Count; 
        }
        
        public void Increase()
        {
            Body.Add(new Pixel(Head.XPos, Head.YPos, ConsoleColor.Green));
        }

        public bool IsCrashInto()
        {
            return Head.XPos == _screenWidth - 1 ||
                    Head.XPos == 0 ||
                    Head.YPos == _screenHeight - 1 ||
                    Head.YPos == 0;
        }
        public bool IsFoodEaten(Pixel food)
        {
            return food.XPos == Head.XPos && food.YPos == Head.YPos;
        }

        public bool IsBitHimself(int index)
        {
            return Body[index].XPos == Head.XPos && Body[index].YPos == Head.YPos;
        }
        public void Move(Direction movement)
        {
            switch (movement)
            {
                case Direction.Up:
                    Head.YPos--;
                    break;
                case Direction.Down:
                    Head.YPos++;
                    break;
                case Direction.Left:
                    Head.XPos--;
                    break;
                case Direction.Right:
                    Head.XPos++;
                    break;
            }

            RemoveTail();
        }

        private void RemoveTail()
        {
            if (this.Length() > _length)
            {
                this.Body.RemoveAt(0);
            }
        }
    }
}

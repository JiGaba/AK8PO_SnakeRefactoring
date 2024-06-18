using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak8PO_SnakeRefactoring
{
    public class Snake
    {
        private int _length;
        public Point Head { get; set; }
        public List<Point> Body { get; set; }
        public Snake(int initLength, int screenWidth, int screenHeight) 
        { 
            _length = initLength;
            Body = new List<Point>();
            Head = new Point(screenWidth / 2, screenHeight / 2, ConsoleColor.Red);
        }
        public void IncreaseLength()
        {
            _length++;
        }
        public int Length()
        {
            return Body.Count; 
        }
        
        public void Add(Point p)
        {
            Body.Add(new Point(p.XPos, p.YPos, ConsoleColor.Magenta));
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

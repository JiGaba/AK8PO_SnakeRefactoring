using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak8PO_SnakeRefactoring
{
    public class Snake
    {
        public Point Head { get; set; }
        public List<Point> Body { get; set; }
        public Snake() { }
    }
}

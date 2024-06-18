using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak8PO_SnakeRefactoring
{
    public interface IFood
    {
        Pixel Position { get; }
        void NextPosition();
    }
}

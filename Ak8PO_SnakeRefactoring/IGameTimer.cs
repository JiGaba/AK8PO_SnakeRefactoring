using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak8PO_SnakeRefactoring
{
    public interface IGameTimer
    {
        void ResetMainLoop();
        void ResetKeyLoop();
        bool IsTimeExpired();
    }
}

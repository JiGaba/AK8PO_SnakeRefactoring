using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak8PO_SnakeRefactoring
{
    public class GameTimer : IGameTimer
    {
        private DateTime _timeMainLoop;
        private DateTime _timeByKeyLoop;

        public GameTimer() { }

        public void ResetMainLoop()
        {
            _timeMainLoop = DateTime.Now;
        }
        public void ResetKeyLoop()
        {
            _timeByKeyLoop = DateTime.Now;
        }
        public bool IsTimeExpired()
        {
            return _timeByKeyLoop.Subtract(_timeMainLoop).TotalMilliseconds > 500;
        }
    }
}

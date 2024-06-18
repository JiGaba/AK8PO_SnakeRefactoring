using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak8PO_SnakeRefactoring
{
    public class GameTimer
    {
        private DateTime _timeMainLoop;
        private DateTime _timeByKeyLoop;
        public GameTimer() { }
        public void MainLoopReset()
        {
            _timeMainLoop = DateTime.Now;
        }
        public void KeyLoopReset()
        {
            _timeByKeyLoop = DateTime.Now;
        }
        public bool TimeExpired()
        {
            return _timeByKeyLoop.Subtract(_timeMainLoop).TotalMilliseconds > 500;
        }
    }
}

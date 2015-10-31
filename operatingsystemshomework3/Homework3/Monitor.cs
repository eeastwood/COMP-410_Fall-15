using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; 
using System.Threading.Tasks;

namespace Homework3
{
    class Monitor
    {
        private SpinLock _lock;

        public Monitor()
        {
            _lock = new SpinLock();
        }

        private void Lock()
        {
            var taken = false;
            while (!taken)
            {
                _lock.TryEnter(ref taken);
            }
        }

        private void Unlock()
        {
            _lock.Exit(true);
        }

        public void Enter()
        {
            Lock();
        }

        public void Exit()
        {
            Unlock();
        }

        public void Pulse()
        {

        }

        public void Wait()
        {
            Unlock();
            Lock();
        }
    }
}

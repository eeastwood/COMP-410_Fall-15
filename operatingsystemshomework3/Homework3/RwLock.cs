using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; 
using System.Threading.Tasks;

namespace Homework3
{
    class RwLock
    {
        private volatile int _numReaders;
        private volatile int _numWriters;
        private volatile int _waitingWriters;
        private SpinLock _lock;

        public RwLock()
        {
            // most similar to this: ReaderWriterLockSlim
            _numReaders = 0;
            _numWriters = 0;
            _waitingWriters = 0;
            _lock = new SpinLock();
        }

        public void ReadLock()
        {
            Lock();
            while (_numWriters > 0 ||
                   _waitingWriters > 0)
            {
                Unlock();
                Lock();
            }
            _numReaders++;
            Unlock();
        }

        public void ReadUnLock()
        {
            Lock();
            _numReaders--;
            Unlock();
        }

        public void WriteLock()
        {
            Lock();
            _waitingWriters++;
            while (_numReaders > 0 ||
                   _numWriters > 0)
            {
                Unlock();
                Lock();
            }
            _waitingWriters--;
            _numWriters++;
            Unlock();
        }

        public void WriteUnLock()
        {
            Lock();
            _numWriters--;
            Unlock();
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
    }
}

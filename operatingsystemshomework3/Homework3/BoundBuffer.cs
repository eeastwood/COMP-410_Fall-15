using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; 
using System.Threading.Tasks;

namespace Homework3
{
        class BoundBuffer<T>
        {
            private const int MaxSize = 5;
            private Queue<T> _queue;
            private Semaphore _full;
            private Semaphore _empty;
            private Monitor _mutex;


            public BoundBuffer()
            {
                _queue = new Queue<T>();
                _mutex = new Monitor();
                _full = new Semaphore(0, MaxSize);
                _empty = new Semaphore(MaxSize, MaxSize);
            }

            public BoundBuffer(int n)
            {
                _queue = new Queue<T>();
                _mutex = new Monitor();
                _full = new Semaphore(0, n);
                _empty = new Semaphore(n, n);
            }

            public T Dequeue()
            {
                _full.WaitOne();
                _mutex.Enter();
                while (_queue.Count == 0){
                _mutex.Wait();
                }
                var item = _queue.Dequeue();
                _mutex.Pulse();
                _mutex.Exit();
                _empty.Release(1);
                return item;
            }

        public void Enqueue(T item)
        {
            _empty.WaitOne();
            _mutex.Enter();
            while (_queue.Count == MaxSize) {
                _mutex.Wait();
            }
            _queue.Enqueue(item);       
            _mutex.Pulse();
            _mutex.Exit();
            _full.Release(1);
        }

        public int Count()
        {
            int i = 0;
            foreach (T value in _queue)
            {
                i++; 
            }

            return i;
        }


        }
    
}

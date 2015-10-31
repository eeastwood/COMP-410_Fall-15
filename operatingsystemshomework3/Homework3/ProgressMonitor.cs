using System;
using System.Collections.Generic;
using System.Threading;

namespace Homework3 {
    internal class ProgressMonitor {
        private readonly List<long> _results;
        public long TotalCount = 0;
        public RwLock _lock = new RwLock(); 

        public ProgressMonitor(List<long> results) {
            _results = results;
        }

        public void Run() {
            while (true) {
                Thread.Sleep(100); // wait for 1/10th of a second

                _lock.WriteLock();
                var currentcount = _results.Count;   //critical sections
                TotalCount += currentcount;

                _results.Clear(); // clear out the current primes to save some memory
                

                if (currentcount > 0) {
                    Console.WriteLine("{0} primes found so far", TotalCount);
                }
                _lock.WriteUnLock(); 

            }
        }
    }
}
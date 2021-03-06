﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Homework3 {
    internal class Calculator {

        public void Run(NumberReader reader) {
            var results = new List<long>();
            var numbersToCheck = new BoundBuffer<long>();
            RwLock _wlock = new RwLock(); 
     

            StartComputationThreads(results, numbersToCheck);

            var progressMonitor = new ProgressMonitor(results);

            new Thread(progressMonitor.Run) {IsBackground = true}.Start();

            _wlock.WriteLock();
            foreach (var value in reader.ReadIntegers()) {
                numbersToCheck.Enqueue(value);                //critical section
            }
           

            while (numbersToCheck.Count() > 0)
            {
                Thread.Sleep(100); // wait for the computation to complete. New Lock?
            }
            
            Console.WriteLine("{0} of the numbers were prime", progressMonitor.TotalCount);
            _wlock.WriteUnLock();

        }

        private static void StartComputationThreads(List<long> results, BoundBuffer<long> numbersToCheck) {
            var threads = CreateThreads(results, numbersToCheck);
            threads.ForEach(thread => thread.Start());
        }
        
        private static List<Thread> CreateThreads(List<long> results, BoundBuffer<long> numbersToCheck) {
            var threadCount = Environment.ProcessorCount*2;

            Console.WriteLine("Using {0} compute threads and 1 I/O thread", threadCount);

            var threads =
                (from threadNumber in Sequence.Create(0, threadCount)
                    let calculator = new IsNumberPrimeCalculator(results, numbersToCheck)
                    let newThread =
                        new Thread(calculator.CheckIfNumbersArePrime) {
                            IsBackground = true,
                            Priority = ThreadPriority.BelowNormal
                        }
                    select newThread).ToList();
            return threads;
        }
    }
}
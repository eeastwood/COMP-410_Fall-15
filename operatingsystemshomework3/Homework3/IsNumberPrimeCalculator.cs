using System;
using System.Collections.Generic;
using System.Threading; 

namespace Homework3 {
    internal class IsNumberPrimeCalculator {
        private readonly ICollection<long> _primeNumbers;  
        private readonly BoundBuffer<long> _numbersToCheck;
        private RwLock mutex = new RwLock();
  

        public IsNumberPrimeCalculator(ICollection<long> primeNumbers, BoundBuffer<long> numbersToCheck) {
            _primeNumbers = primeNumbers;
            _numbersToCheck = numbersToCheck;
       
        }

        public void CheckIfNumbersArePrime() {
            while (true) {

                mutex.WriteLock();
                var numberToCheck = _numbersToCheck.Dequeue();       //critical section
                
                if (IsNumberPrime(numberToCheck)) {
                    _primeNumbers.Add(numberToCheck);
                }
                mutex.WriteUnLock(); 
            }
        }

        private bool IsNumberPrime(long numberWeAreChecking) {
            const long firstNumberToCheck = 3;

            if (numberWeAreChecking % 2 == 0) {
                return false;
            }
            var lastNumberToCheck = Math.Sqrt(numberWeAreChecking);
            for (var currentDivisor = firstNumberToCheck; currentDivisor < lastNumberToCheck; currentDivisor += 2) {
                if (numberWeAreChecking % currentDivisor == 0) {
                    return false;
                }
            }
            return true;
        }
    }
}
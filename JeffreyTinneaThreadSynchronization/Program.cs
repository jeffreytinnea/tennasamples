using System;
using System.Threading;

namespace JeffreyTinneaThreadSynchronization
{
    class Program
    {
        // Lock object for threads to interact with _currentNumber
        static readonly object _threadLock = new object();

        // Max number to count up to for the program
        static readonly int _maxNumber = 100;

        // Current number to be counted. Must lock on _threadLock to maintain thread safety.
        // Default value is starting value for counting.
        static int _currentNumber = 1;

        /// <summary>
        /// Thread method to count and print numbers from starting _currentNumber to _maxNumber
        /// </summary>
        /// <param name="validationExpression">A function returning true if this thread should print and increment the current number.
        /// Evaluation occurs inside the lock so it is safe to reference _currentNumber.</param>
        static void PrintNumber(Func<bool> validationExpression)
        {
            while (_currentNumber <= _maxNumber)
            {
                lock (_threadLock)
                {
                    // Only print and increment if the validation expression is true. Additionally, we need
                    // to verify _currentNumber <= _maxNumber again here because the loop's evaluation is outside the lock
                    if (_currentNumber <= _maxNumber && validationExpression())
                    {
                        Console.WriteLine($"Thread {Thread.CurrentThread.Name}: The number is '{_currentNumber++}'");
                    }
                }
            }
        }
        
        /// <summary>
        /// Main method which starts the threads
        /// </summary>
        /// <param name="args">Not used</param>
        static void Main(string[] args)
        {
            var oddsThread = new Thread(() => PrintNumber(() => _currentNumber % 2 == 1)) { Name = "1" };
            var evensThread = new Thread(() => PrintNumber(() => _currentNumber % 2 == 0)) { Name = "2" };

            oddsThread.Start();
            evensThread.Start();
        }
    }
}

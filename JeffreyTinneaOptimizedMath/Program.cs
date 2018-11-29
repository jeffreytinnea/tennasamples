using System;

namespace JeffreyTinneaOptimizedMath
{
    class Program
    {
        // Number to start counting with (inclusive)
        static readonly int _startNumber = 1;
        
        // Number to stop counting with (inclusive)
        static readonly int _endNumber = 100;

        /// <summary>
        /// Application which loops through numbers from fixed 1 to 100 and prints a relevant property about each one.
        /// </summary>
        /// <param name="args">Not used</param>
        static void Main(string[] args)
        {
            // Loop for 1 through 100 inclusive per requirement
            for (int i = _startNumber; i <= _endNumber; i++)
            {
                // Checks are in order of priority to print: ex/ 'divisible by two and three' takes priority over 'even'.
                var divisibleMessage =
                    i % 6 == 0 ? "divisible by two and three." : // A number divisible by 2 and 3 will be divisible by 6 as 2 and 3 are prime factors of 6.
                    i % 3 == 0 ? "divisible by three." :
                    i % 2 == 0 ? "even." : "odd.";
                Console.WriteLine($"The number '{i}' is {divisibleMessage}");
            }
        }
    }
}

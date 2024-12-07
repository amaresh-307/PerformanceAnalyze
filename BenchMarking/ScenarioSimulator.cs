using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchMarking
{
    internal static class ScenarioSimulator
    {
        public static int[] GenerateRandomNumbers(int startRange, int endRange, int arraySize)
        {
            // Validate inputs
            if (arraySize <= 0 || startRange > endRange || arraySize > 30000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input.");
                Console.ForegroundColor = ConsoleColor.White;
                return [];
            }

            Random random = new();
            int[] randomNumbers = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                randomNumbers[i] = random.Next(startRange, endRange + 1); // endRange + 1 because Next is exclusive at the upper bound
            }

            return randomNumbers;
        }

    }
}

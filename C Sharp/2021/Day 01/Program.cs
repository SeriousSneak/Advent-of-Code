/* Advent of Code 2021
 * Day 1
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on December 1, 2021
 * Part 2 finished on December 1, 2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2021\Advent-of-Code-2021\Day 1\input.txt");

            var linesList = new List<string>(lines);

            
            int numberOfIncreasesPart1 = 0;
            int numberOfIncreasesPart2 = 0;


            // Part 1
            int currentReading = 0;
            int previousReading = 0;
            for (int count = 1; count < linesList.Count; count++)
            {
                currentReading = Convert.ToInt32(linesList[count]);
                previousReading = Convert.ToInt32(linesList[count - 1]);

                if (currentReading > previousReading)
                {
                    numberOfIncreasesPart1++;
                }
            }

            // Part 2
            int firstSum = 0;
            int secondSum = 0;
            for (int count = 0; count < (linesList.Count - 3); count++)
            {
                firstSum = Convert.ToInt32(linesList[count]) + Convert.ToInt32(linesList[count + 1]) + Convert.ToInt32(linesList[count + 2]);
                secondSum = Convert.ToInt32(linesList[count + 1]) + Convert.ToInt32(linesList[count + 2]) + Convert.ToInt32(linesList[count + 3]);

                if (secondSum > firstSum)
                {
                    numberOfIncreasesPart2++;
                }
            }

            
            Console.WriteLine("For Part 1 there are " + numberOfIncreasesPart1 + " increases.");
            Console.WriteLine("For Part 2 there are " + numberOfIncreasesPart2 + " increases.");

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}

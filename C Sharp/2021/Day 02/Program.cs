/* Advent of Code 2021
 * Day 2
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on December 2, 2021
 * Part 2 finished on December 2, 2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            var lines = File.ReadLines(@"C:\Temp\Drew's code repos\Advent-of-Code-2021\Day 2\input.txt");

            // creating a List with the input
            var linesList = new List<string>(lines);

            int horizontalPositionPart1 = 0;
            int horizontalPositionPart2 = 0;
            int depthPart1 = 0;
            int depthPart2 = 0;
            int aim = 0;

            // Part 1
            for (int loop = 0; loop < linesList.Count; loop++)
            {
                string movement = linesList[loop];

                //This will split a string based on a single character
                string[] subStrings = movement.Split(' ');

                string direction = subStrings[0];
                int distance = Convert.ToInt32(subStrings[1]);

                if (direction == "forward")
                {
                    horizontalPositionPart1 += distance;
                }
                else if (direction == "up")
                {
                    depthPart1 -= distance;

                }
                else if (direction == "down")
                {
                    depthPart1 += distance;
                }
            }

            // Part 2
            for (int loop = 0; loop < linesList.Count; loop++)
            {
                string movement = linesList[loop];

                //This will split a string based on a single character
                string[] subStrings = movement.Split(' ');

                string direction = subStrings[0];
                int distance = Convert.ToInt32(subStrings[1]);

                if (direction == "forward")
                {
                    horizontalPositionPart2 += distance;
                    depthPart2 += aim * distance;
                }
                else if (direction == "up")
                {
                    aim -= distance;

                }
                else if (direction == "down")
                {
                    aim += distance;
                }
            }

            int answerPart1 = depthPart1 * horizontalPositionPart1;
            int answerPart2 = depthPart2 * horizontalPositionPart2;

            Console.WriteLine("In Part 1 the depth multiplied by the horizontal position is " + depthPart1 + " * " + horizontalPositionPart1 + " = " + answerPart1);
            Console.WriteLine("In Part 2 the depth multiplied by the horizontal position is " + depthPart2 + " * " + horizontalPositionPart2 + " = " + answerPart2);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
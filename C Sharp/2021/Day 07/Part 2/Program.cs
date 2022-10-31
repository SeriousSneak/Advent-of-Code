/* Advent of Code 2021
 * 
 * Programmer: Andrew Stobart
 * Date: October 1, 2022
 *
 * Project details
 *    Targeting .net Core 3.1
 *    Created with Visual Studio 2022 on Windows 11
 *
 * Day 7 Part 2
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            //windows
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2021\Advent-of-Code-2021\Day 7\Part 1\input.txt");

            //mac
            //var lines = File.ReadLines(@"/Users/andrew/Temp/Advent-of-Code-2021/Day 7/Part 2/input.txt");

            var linesList = new List<string>(lines);

            //the input file has a single line, so I have hard coded index 0 here
            string[] values = linesList[0].Split(',');
            
            
            int[] crabValuesArray = values.Select(int.Parse).ToArray();
            

            //calculate fuel use
            int totalLowestFuelUsed = 0;
            int totalBestPosition = 0;
            int isThisTheLowestFuelUsed = 0;

            for (int position = 0; position < crabValuesArray.Length; position++)
            {
                if (totalLowestFuelUsed == 0)
                {
                    totalLowestFuelUsed = findFuelUsed(position, crabValuesArray);
                    totalBestPosition = position;
                }
                else            
                {
                    isThisTheLowestFuelUsed = findFuelUsed(position, crabValuesArray);
                    if (isThisTheLowestFuelUsed < totalLowestFuelUsed)
                    {
                        totalLowestFuelUsed = isThisTheLowestFuelUsed;
                        totalBestPosition = position;
                    }
                }
            }

            watch.Stop();
            
            Console.WriteLine("Total fuel used is: " + totalLowestFuelUsed);
            Console.WriteLine("Best position is: " + totalBestPosition);
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            //answer is 93214037
        }

        static int findFuelUsed (int position, int[] crabValuesArray)
        {
            int totalFuelUsed = 0;
            for (int loop = 0; loop < crabValuesArray.Length; loop++)
            {
                //find how many spaces the crab needs to move
                int difference = Math.Abs(crabValuesArray[loop] - position);

                for (int spacesMoved = 1; spacesMoved <= difference; spacesMoved++)
                {
                    totalFuelUsed += spacesMoved; 
                }

                /*
                16-5 = 11 jumps

                loop 11 times
                {
                    1+2+3+4+5+6+7+8+9+10+11
                }

                */
            }
            return totalFuelUsed;
        }
    }
}

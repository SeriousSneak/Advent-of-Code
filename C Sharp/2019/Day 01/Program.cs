// See https://aka.ms/new-console-template for more information

/* Advent of Code 2019
 * Day 1
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on October 27, 2022
 * Part 2 finished on October 27, 2022
 *
 * Project details
 *    Targeting .NET 6.0
 *    Created with Visual Studio 2022 on Windows 11 and Visual Studio 17 on MacOS 
 */


var watch = new System.Diagnostics.Stopwatch();
watch.Start();

// windows
var lines = File.ReadLines(@"C:\Temp\Repos\Advent-of-Code\C Sharp\2019\Day 01\input.txt");

// mac
//var lines = File.ReadLines(@"/Users/andrew/Temp/Advent-of-Code-2021/Day 11/input.txt");

int theCountPart1 = 0;
int singleModuleCalculationPart1;

int theCountPart2 = 0;
int singleModuleCalculationPart2 = 0;
int loopAtLeastOnce = 0;

foreach (var line in lines)
{
    // Part 1
    // this basically always rounds down for the division because we are using Ints.
    singleModuleCalculationPart1 = (Convert.ToInt32(line) / 3) - 2;
    theCountPart1 += singleModuleCalculationPart1;


    // Part 2
    do
    {
        if (loopAtLeastOnce == 1)
        {
            singleModuleCalculationPart2 = ((singleModuleCalculationPart2) / 3) - 2;
        }
        else
        {
            singleModuleCalculationPart2 = (Convert.ToInt32(line) / 3) - 2;
            loopAtLeastOnce = 1;
        }

        if (singleModuleCalculationPart2 > 0)
        {
            theCountPart2 += singleModuleCalculationPart2;
        }

    } while (singleModuleCalculationPart2 > 0);

    loopAtLeastOnce = 0;
}

// Part 1 answer is 3515171.
// Part 2 answer is 5269882.

Console.WriteLine("In Part 1, the sum of the fuel requirements is {0}.", theCountPart1);
Console.WriteLine("In Part 2, the sum of the fuel requirements is {0}.", theCountPart2);


watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();
// See https://aka.ms/new-console-template for more information
/* Advent of Code 2021
 * 
 * Programmer: Andrew Stobart
 * Date: October 3, 2022
 *
 * Project details
 *    Targeting .NET 6.0
 *    Created with Visual Studio 2022 on Windows 11 and MacOS
 *
 * Day 8 Part 1
 * 
 */


using System.Globalization;

var watch = new System.Diagnostics.Stopwatch();
watch.Start();


//windows
var lines = File.ReadLines(@"C:\Temp\Drew's code repos\Advent-of-Code-2021\Day 8\Part 1\input.txt");

//mac
//var lines = File.ReadLines(@"/Users/andrew/Temp/Advent-of-Code-2021/Day 8/Part 2/input.txt");

int digitCount = 0;

foreach (var line in lines)
{
    string[] stringSeparators = new string[] { " ","|" };
    string[] subStrings = line.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

    for (int digit=10; digit < 14; digit++)
    {
        if (subStrings[digit].Length == 2 || subStrings[digit].Length == 4 || subStrings[digit].Length == 3 || subStrings[digit].Length == 7)
        {
                digitCount++;
        }
    }
}

//answer is 521
Console.WriteLine("There are " + digitCount + " digits that are either 1, 4, 7, or 8.");

watch.Stop();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine("");
Console.WriteLine("Press any key to continue.");
Console.ReadKey();
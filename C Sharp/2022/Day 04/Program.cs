// See https://aka.ms/new-console-template for more information

/* Advent of Code 2022
 * Day 4
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on December 8, 2022
 * Part 2 finished on December 8, 2022
 *
 * Project details
 *    Targeting .NET 7.0
 *    Created with Visual Studio 2022 on Windows 11 and Visual Studio 17 on MacOS 
 */

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

// Windows
string[] contents = File.ReadAllLines(@"C:\Temp\Repos\Advent-of-Code\C Sharp\2022\Day 04\input.txt");

// Mac
//string[] contents = File.ReadAllLines(@"/Users/andrew/Temp/Advent-of-Code/C Sharp/2022/Day 04/inputtest.txt");


int assignmentPairCount = 0;
int assignmentPairOverlap = 0;
for (int x = 0; x < contents.Length; x++)
{
    // This will split a string based on a single character
    string[] subStrings = contents[x].Split('-', ',');

    // Part 1
    if (Convert.ToInt32(subStrings[0]) <= Convert.ToInt32(subStrings[2]) && Convert.ToInt32(subStrings[1]) >= Convert.ToInt32(subStrings[3]))
        assignmentPairCount++;

    else if (Convert.ToInt32(subStrings[0]) >= Convert.ToInt32(subStrings[2]) && Convert.ToInt32(subStrings[1]) <= Convert.ToInt32(subStrings[3]))
        assignmentPairCount++;
    

    // Part 2
    if (Convert.ToInt32(subStrings[0]) <= Convert.ToInt32(subStrings[3]) && Convert.ToInt32(subStrings[2]) <= Convert.ToInt32(subStrings[1]))
        assignmentPairOverlap++;
}


Console.WriteLine("For Part 1, the number of assignment pairs where one range fully contains the other is {0}.", assignmentPairCount);
Console.WriteLine("For Part 2, the number of assignment pairs where the ranges overlap each other is {0}.", assignmentPairOverlap);


watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();
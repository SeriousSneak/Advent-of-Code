// See https://aka.ms/new-console-template for more information

/* Advent of Code 2022
 * Day 5
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on 
 * Part 2 finished on 
 *
 * Project details
 *    Targeting .NET 7.0
 *    Created with Visual Studio 2022 on Windows 11 and Visual Studio 17 on MacOS 
 */

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

// Windows
//string[] contents = File.ReadAllLines(@"C:\Temp\Repos\Advent-of-Code\C Sharp\2022\Day 05\inputtest.txt");

// Mac
string[] contents = File.ReadAllLines(@"/Users/andrew/Repos/Advent-of-Code/C Sharp/2022/Day 05/inputtest.txt");


// Determine how many stacks of crates we have

int stackCount = 0;

foreach (string line in contents)
{
    if (line[1] == '1') 
    {
        // we have found the line that we can use to determine the number or stacks
        int secondLast = line.Length - 1;
        char count = Convert.ToChar(line[secondLast]);
        stackCount = Convert.ToInt32(stackCount);
        break;
    }
}


Console.WriteLine("There are {0} stacks.", stackCount);

//Console.WriteLine("For Part 1, ... {0}.");
//Console.WriteLine("For Part 2, ... {0}.");


watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();
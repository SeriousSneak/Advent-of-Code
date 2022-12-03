// See https://aka.ms/new-console-template for more information

/* Advent of Code 2022
 * Day 3
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

//Windows
string[] contents = File.ReadAllLines(@"C:\Temp\Repos\Advent-of-Code\C Sharp\2022\Day 01\input.txt");

//Mac
//string[] contents = File.ReadAllLines(@"/Users/andrew/Temp/Advent-of-Code/C Sharp/2022/Day 01/inputtest.txt");





Console.WriteLine("For Part 1, ... {0}.");
Console.WriteLine("For Part 2, ... {0}.");


watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();
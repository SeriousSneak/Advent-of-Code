// See https://aka.ms/new-console-template for more information
using System.Numerics;

// See https://aka.ms/new-console-template for more information


/* Advent of Code 2023
 * Day 2
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on
 * Part 2 finished on
 *
 * Project details
 *    Targeting .NET 8.0
 *    Created with Visual Studio 2022 on Windows 11
 */



var watch = new System.Diagnostics.Stopwatch();
watch.Start();

// Windows
string[] contents = File.ReadAllLines(@"\\Mac\Home\Documents\Advent-of-Code\C Sharp\2023\Day 02\input.txt");

// constants
int redConst = 12;
int greenConst = 13;
int blueConst = 14;
int gameNumber = 1;
int part1Answer = 0;

// need to parse the input file
foreach (string line in contents)
{
    string[] stringSeparators = new string[] { ": ", ", ", "; "," " };
    string[] subStrings = line.Split(stringSeparators, StringSplitOptions.None);

    int red = 0;
    int green = 0;
    int blue = 0;

    for (int x = 3; x < subStrings.Length; x+=2)
    {
        // colour names will be in odd cells, and the number of them will be the cell before
        // Cell 0: Game
        // Cell 1: Game number
        // Cell 2: numer of balls of which colour is in Cell 3
        // Cell 4: number of balls of which colour is int cell 5

        switch (subStrings[x])
        {
            case "blue":
                blue += Convert.ToInt32(subStrings[x - 1]);
                break;

            case "green":
                green += Convert.ToInt32(subStrings[x - 1]);
                break;

            case "red":
                red += Convert.ToInt32(subStrings[x - 1]);
                break;

            default:
                Console.WriteLine("An unrecognized colour was found");
                break;
        }
    }
    Console.WriteLine("Game {0}: I found {1} blue, {2} green, and {3} red.", gameNumber, blue, green, red);

    if ((blue <= blueConst) && (green <= greenConst) && (red <= redConst))
    {
        Console.WriteLine("Game {0} would have been possible.", gameNumber);
        part1Answer += gameNumber;
    }
    gameNumber++;

}                                                      


// For part 1 346 is too low

Console.WriteLine("For Part 1 the total sum of the possible game IDs is {0}.", part1Answer);
Console.WriteLine("For Part 2 the total sum is...");


watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();
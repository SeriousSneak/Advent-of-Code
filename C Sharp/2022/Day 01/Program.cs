// See https://aka.ms/new-console-template for more information

/* Advent of Code 2022
 * Day 1
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on December 2, 2022
 * Part 2 finished on December 2, 2022
 *
 * Project details
 *    Targeting .NET 7.0
 *    Created with Visual Studio 2022 on Windows 11 and Visual Studio 17 on MacOS 
 */

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

// Windows
// string[] contents = File.ReadAllLines(@"C:\Temp\Repos\Advent-of-Code\C Sharp\2022\Day 01\input.txt");

// Mac
string[] contents = File.ReadAllLines(@"/Users/andrew/Temp/Advent-of-Code/C Sharp/2022/Day 01/input.txt");


int elfCaloriesTotal = 0;
List<int> topThree = new List<int>();


for (int x = 0; x < contents.Length; x++)
{
    if (contents[x] != "")
    {
        elfCaloriesTotal += Convert.ToInt32(contents[x]);
    }

    // we also check x == contents.length - 1 to see if we are looking at the last entry of the input 
    if (contents[x] == "" || x == (contents.Length -1 ))
    {
        topThree.Add(elfCaloriesTotal);

        elfCaloriesTotal = 0;
    }
}

topThree.Sort(); // sorts with the smallest number being in the 0 position
topThree.Reverse(); // reverse sorts so that the largest number is in the 0 position so that I can reference it below with topThree[0]

Console.WriteLine("For Part 1, the elf carrying the most calories is carrying {0} calories.", topThree[0]);
Console.WriteLine("For Part 2, the sum of the calories carried by the top three elves is {0} calories.", topThree[0] + topThree[1] + topThree[2]);


watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();
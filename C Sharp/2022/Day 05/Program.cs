// See https://aka.ms/new-console-template for more information

/* Advent of Code 2022
 * Day 5
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on December 19, 2022
 * Part 2 finished on December 19, 2022
 *
 * Project details
 *    Targeting .NET 7.0
 *    Created with Visual Studio 2022 on Windows 11 and Visual Studio 17 on MacOS 
 */

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

// Windows
string[] contents = File.ReadAllLines(@"C:\Temp\Repos\Advent-of-Code\C Sharp\2022\Day 05\aoc_2022_day05_large_input.txt"); // in 15 mins my code had done 150 moves out of 100,000
//string[] contents = File.ReadAllLines(@"C:\Temp\Repos\Advent-of-Code\C Sharp\2022\Day 05\input.txt");  // my code ran in 93 ms

// Mac
//string[] contents = File.ReadAllLines(@"/Users/andrew/Repos/Advent-of-Code/C Sharp/2022/Day 05/inputtest.txt");


// Determine how many stacks of crates we have
int stackCount = 0;
int rowWhichHoldsStackNumbers = -1;
foreach (string line in contents)
{
    if (line[1] == '1') 
    {
        // we have found the line that we can use to determine the number or stacks
        char count = Convert.ToChar(line[line.Length - 2]);

        if (count == ' ') // this will trigger when I use the extra long input called "aoc_2022_day05_large_input.txt" as there is an extra space at the end of the stack lines at the top
            count = Convert.ToChar(line[line.Length - 3]);

        stackCount = int.Parse(count.ToString());
        break;
    }
    rowWhichHoldsStackNumbers++;
}
Console.WriteLine("There are {0} stacks.", stackCount);

List<List<char>> stacksListPart1 = new List<List<char>>();
List<List<char>> stacksListPart2 = new List<List<char>>();


for (int i = 0; i < 9; i++)
{
    stacksListPart1.Add(new List<char>());
    stacksListPart2.Add(new List<char>());
}


// Fill stacksList with the input
for (int i = rowWhichHoldsStackNumbers; i >=0; i--)
{
    int inputPosition = 1;
    string currentRow = contents[i];

    for (int x = 0; x < stackCount; x++)
    {    
        if (currentRow[inputPosition] != ' ')
        {
            stacksListPart1[x].Add(currentRow[inputPosition]);
            stacksListPart2[x].Add(currentRow[inputPosition]);
        }
        inputPosition += 4;
    }
}


// Code to move our items around
int loopCount = 1;
Console.CursorVisible = false;
foreach (string line in contents)
{
    Console.SetCursorPosition(0, Console.CursorTop);
    string[] subStrings = line.Split(' ');

    if (subStrings[0] != "move")
    {
        continue;
    }

    int amountToMove = int.Parse(subStrings[1]);
    int moveFrom = int.Parse(subStrings[3]);
    int moveTo = int.Parse(subStrings[5]);


    // Part 1
    for (int x = 0; x < amountToMove; x++)
    {
        stacksListPart1[moveTo - 1].Add(stacksListPart1[moveFrom - 1][(stacksListPart1[moveFrom - 1].Count - 1)]);
        stacksListPart1[moveFrom - 1].RemoveAt(stacksListPart1[moveFrom - 1].Count - 1);
    }
    

    // Part 2
    int positionToRemove = stacksListPart2[moveFrom - 1].Count - amountToMove;
    for (int x = 0; x < amountToMove; x++)
    {
        stacksListPart2[moveTo - 1].Add(stacksListPart2[moveFrom - 1][positionToRemove]);
        stacksListPart2[moveFrom - 1].RemoveAt(positionToRemove);
    }

    Console.Write("Performing move number {0}.", loopCount);
    
    loopCount++;
}
Console.CursorVisible = true;
Console.WriteLine();
Console.WriteLine();

// I couldn't figure out a way to handle a sincle output for both my test code (3 stacks) and my question code (9 stacks). In both situations, i generate 9 stacks, but in my
// test code, it will produce an error when I try to print the last item in stacks that don't have any items. This is why I used this IF statement. I'm sure I could hae made
// the code smarter by only generating enough lists to match the input, and then just looped that number of times for the output.
if(stackCount == 3)
{
    Console.WriteLine("For Part 1, the crates at the top of the stacks starting with stack 1 are {0}{1}{2}",
    stacksListPart1[0].Last(),
    stacksListPart1[1].Last(),
    stacksListPart1[2].Last());

    Console.WriteLine("For Part 2, the crates at the top of the stacks starting with stack 1 are {0}{1}{2}",
    stacksListPart2[0].Last(),
    stacksListPart2[1].Last(),
    stacksListPart2[2].Last());
}
else if(stackCount == 9)
{
    Console.WriteLine("For Part 1, the crates at the top of the stacks starting with stack 1 are {0}{1}{2}{3}{4}{5}{6}{7}{8}",
    stacksListPart1[0].Last(),
    stacksListPart1[1].Last(),
    stacksListPart1[2].Last(),
    stacksListPart1[3].Last(),
    stacksListPart1[4].Last(),
    stacksListPart1[5].Last(),
    stacksListPart1[6].Last(),
    stacksListPart1[7].Last(),
    stacksListPart1[8].Last());

    Console.WriteLine("For Part 2, the crates at the top of the stacks starting with stack 1 are {0}{1}{2}{3}{4}{5}{6}{7}{8}",
    stacksListPart2[0].Last(),
    stacksListPart2[1].Last(),
    stacksListPart2[2].Last(),
    stacksListPart2[3].Last(),
    stacksListPart2[4].Last(),
    stacksListPart2[5].Last(),
    stacksListPart2[6].Last(),
    stacksListPart2[7].Last(),
    stacksListPart2[8].Last());
}


watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();
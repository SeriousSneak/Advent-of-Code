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

using System.Security.Cryptography.X509Certificates;

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

// Windows
string[] contents = File.ReadAllLines(@"C:\Temp\Repos\Advent-of-Code\C Sharp\2022\Day 05\inputtest.txt");

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

//List<List<char>> stacksListPart1 = new List<List<char>>(stacksList);
//List<List<char>> stacksListPart2 = new List<List<char>>(stacksList);

// Code to move our items around
foreach (string line in contents)
{

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
}

char stackOneTop = ' ';
char stackTwoTop = ' ';
char stackThreeTop = ' ';
char stackFourTop = ' ';
char stackFiveTop = ' ';
char stackSixTop = ' ';
char stackSevenTop = ' ';
char stackEightTop = ' ';
char stackNineTop = ' ';


// this can be a loop
if (stacksListPart1[0].Count > 0)
    stackOneTop = stacksListPart1[0][stacksListPart1[0].Count - 1];

if (stacksListPart1[1].Count > 0)
    stackTwoTop = stacksListPart1[1][stacksListPart1[1].Count - 1];

if (stacksListPart1[2].Count > 0)
    stackThreeTop = stacksListPart1[2][stacksListPart1[2].Count - 1];

if (stacksListPart1[3].Count > 0)
    stackFourTop = stacksListPart1[3][stacksListPart1[3].Count - 1];

if (stacksListPart1[4].Count > 0)
    stackFiveTop = stacksListPart1[4][stacksListPart1[4].Count - 1];

if (stacksListPart1[5].Count > 0)
    stackSixTop = stacksListPart1[5][stacksListPart1[5].Count - 1];

if (stacksListPart1[6].Count > 0)
    stackSevenTop = stacksListPart1[6][stacksListPart1[6].Count - 1];

if (stacksListPart1[7].Count > 0)
    stackEightTop = stacksListPart1[7][stacksListPart1[7].Count - 1];

if (stacksListPart1[8].Count > 0)
    stackNineTop = stacksListPart1[8][stacksListPart1[8].Count - 1];


Console.WriteLine("For Part 1, the crates at the top of the stacks starting with stack 1 are {0}{1}{2}{3}{4}{5}{6}{7}{8}",
stackOneTop,
stackTwoTop, 
stackThreeTop, 
stackFourTop, 
stackFiveTop,
stackSixTop, 
stackSevenTop,
stackEightTop, 
stackNineTop);

    /*
        stacksListPart1[0].LastOrDefault(' '),
    stacksListPart1[1].LastOrDefault(' '),
    stacksListPart1[2].LastOrDefault(' '),
    stacksListPart1[3].LastOrDefault(' '),
    stacksListPart1[4].LastOrDefault(' '),
    stacksListPart1[5].LastOrDefault(' '),
    stacksListPart1[6].LastOrDefault(' '),
    stacksListPart1[7].LastOrDefault(' '),
    stacksListPart1[8].LastOrDefault(' '),
    stacksListPart1[9].LastOrDefault(' '));
    */


/*
Console.WriteLine("The crates at the top of the stacks starting with stack 1, are {0}{1}{2}{3}{4}{5}{6}{7}{8}",
    stacksList[0][stacksList[0].Count - 1],
    stacksList[1][stacksList[1].Count - 1],
    stacksList[2][stacksList[2].Count - 1],
    stacksList[3][stacksList[3].Count - 1],
    stacksList[4][stacksList[4].Count - 1],
    stacksList[5][stacksList[5].Count - 1],
    stacksList[6][stacksList[6].Count - 1],
    stacksList[7][stacksList[7].Count - 1],
    stacksList[8][stacksList[8].Count - 1]);
*/
//
//Console.WriteLine("For Part 1, ... {0}.");
//Console.WriteLine("For Part 2, ... {0}.");


watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();
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
string[] contents = File.ReadAllLines(@"C:\Temp\Repos\Advent-of-Code\C Sharp\2022\Day 05\input.txt");

// Mac
//string[] contents = File.ReadAllLines(@"/Users/andrew/Repos/Advent-of-Code/C Sharp/2022/Day 05/inputtest.txt");


// Determine how many stacks of crates we have
int stackCount = 0;
int rowWhichHoldsStackNumbers = 0;
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

List<List<char>> stacksList = new List<List<char>>();

for (int i = 0; i < 9; i++)
{
    stacksList.Add(new List<char>());
}

int pause = 0;

for (int i = rowWhichHoldsStackNumbers; i >=0; i--)
{
    int inputPosition = 1;
    string currentRow = contents[i];
    /*
    if (currentRow[1] != ' ')
        stacksList[0].Add(currentRow[1]);

    if (currentRow[5] != ' ')
        stacksList[1].Add(currentRow[5]);

    if (currentRow[9] != ' ')
        stacksList[2].Add(currentRow[9]);
    */

    for (int x = 0; x < stackCount; x++)
    {    
        if (currentRow[inputPosition] != ' ')
        {
            stacksList[x].Add(currentRow[inputPosition]);
        }
        inputPosition += 4;
    }

}


// Add initial allotment to our stacks
// Test Input hard coded
/*
stacksList[0].Add('Z');
stacksList[0].Add('N');
stacksList[1].Add('M');
stacksList[1].Add('C');
stacksList[1].Add('D');
stacksList[2].Add('P');
*/



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

    for (int x = 0; x < amountToMove; x++)
    {
        stacksList[moveTo - 1].Add(stacksList[moveFrom - 1][(stacksList[moveFrom - 1].Count - 1)]);
        stacksList[moveFrom - 1].RemoveAt(stacksList[moveFrom - 1].Count - 1);
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
if (stacksList[0].Count > 0)
    stackOneTop = stacksList[0][stacksList[0].Count - 1];

if (stacksList[1].Count > 0)
    stackTwoTop = stacksList[1][stacksList[1].Count - 1];

if (stacksList[2].Count > 0)
    stackThreeTop = stacksList[2][stacksList[2].Count - 1];

if (stacksList[3].Count > 0)
    stackFourTop = stacksList[3][stacksList[3].Count - 1];

if (stacksList[4].Count > 0)
    stackFiveTop = stacksList[4][stacksList[4].Count - 1];

if (stacksList[5].Count > 0)
    stackSixTop = stacksList[5][stacksList[5].Count - 1];

if (stacksList[6].Count > 0)
    stackSevenTop = stacksList[6][stacksList[6].Count - 1];

if (stacksList[7].Count > 0)
    stackEightTop = stacksList[7][stacksList[7].Count - 1];

if (stacksList[8].Count > 0)
    stackNineTop = stacksList[8][stacksList[8].Count - 1];


Console.WriteLine("The crates at the top of the stacks starting with stack 1 are {0}{1}{2}{3}{4}{5}{6}{7}{8}",
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
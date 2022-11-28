// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;


/* Advent of Code 2019
 * Day 2
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on November 28, 2022
 * Part 2 finished on November 28, 2022
 *
 * Project details
 *    Targeting .NET 7.0
 *    Created with Visual Studio 2022 on Windows 11 and Visual Studio 17 on MacOS 
 */

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

// windows
string contents = File.ReadAllText(@"C:\Temp\Repos\Advent-of-Code\C Sharp\2019\Day 02\input.txt");

// mac
//var lines = File.ReadLines(@"/Users/andrew/Temp/Advent-of-Code/C Sharp/2019/Day 02/input.txt");


string[] stringSeparators = new string[] {","};
string[] dataString = contents.Split(stringSeparators, StringSplitOptions.None);

List<int> dataList = new List<int>();

foreach (string data in dataString)
{
    dataList.Add(Convert.ToInt32(data));
}


// part 1
List<int> part1ClonedList = dataList.ToList();
int part1Position0 = processInstruction(part1ClonedList, 12, 2);


// Part 1 answer is 3224742
Console.WriteLine("In Part 1, the value at position 0 is {0}.", part1Position0);
//Console.WriteLine("In Part 2, the sum of the fuel requirements is {0}.", theCountPart2);


// Part 2
for (int noun = 0; noun <= 99; noun++)
{
    for (int verb = 0; verb <= 99; verb++)
    {
        List<int> part2ClonedList = dataList.ToList();
        
        if (processInstruction(part2ClonedList, noun, verb) == 19690720)
        {
            int answer = (100 * noun) + verb;
            // Part 2 answer is 7960
            Console.WriteLine("In Part 2, 100 * noun + verb gives us {0}.", answer);
            noun = int.MaxValue - 1;
            break;
        }
    }
}

watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();

static int processInstruction (List<int> dataList, int noun, int verb)
{
    dataList[1] = noun;
    dataList[2] = verb;
    for (int i = 0; i < dataList.Count; i++)
    {
        int position1 = dataList[i + 1];
        int position2 = dataList[i + 2];
        int position3 = dataList[i + 3];

        if (dataList[i] == 1)
        {
            // addition here
            dataList[position3] = dataList[position1] + dataList[position2];

            i += 3; //I'm only adding 3 here as the start of the loop will add another to i, making the total add 4
        }
        else if (dataList[i] == 2)
        {
            // multiplication here
            dataList[position3] = dataList[position1] * dataList[position2];

            i += 3;
        }
        else if (dataList[i] == 99)
        {
            break;
        }
    }
    return dataList[0];
}
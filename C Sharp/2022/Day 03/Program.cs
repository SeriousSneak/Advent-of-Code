// See https://aka.ms/new-console-template for more information

/* Advent of Code 2022
 * Day 3
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on December 6, 2022
 * Part 2 finished on December 6, 2022
 *
 * Project details
 *    Targeting .NET 7.0
 *    Created with Visual Studio 2022 on Windows 11 and Visual Studio 17 on MacOS 
 */

//using System.Windows.Media;

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

//Windows
string[] contents = File.ReadAllLines(@"C:\Temp\Repos\Advent-of-Code\C Sharp\2022\Day 03\input.txt");

//Mac
//string[] contents = File.ReadAllLines(@"/Users/andrew/Temp/Advent-of-Code/C Sharp/2022/Day 03/inputtest.txt");

// These two lists were used to debug the program and aren't used to calculate the final answer
List<char> partOneCommonItems = new List<char>();
List<char> partTwoCommonItems = new List<char>();

int partOnePriorityScore = 0;
int partTwoPriorityScore = 0;

// Part 1
foreach (string line in contents)
{
    string firstHalf = line.Substring(0, line.Length / 2);
    string secondHalf = line.Substring(line.Length / 2, line.Length / 2);

    foreach (char letter in firstHalf)
    {
        if (secondHalf.Contains(letter))
        {
            partOneCommonItems.Add(letter);

            // score calculation
            if (Char.IsLower(letter))
                partOnePriorityScore += calculatePriorityScore(letter);
            else
                partOnePriorityScore += calculatePriorityScore(letter);
            
            break;
        }
    }
}

// Part 2
for (int x = 0; x <= contents.Length - 3; x += 3)
{
    string firstRuckSack = contents[x];
    string secondRuckSack = contents[x + 1];
    string thirdRuckSack = contents[x + 2];

    foreach (char letter in firstRuckSack) 
    { 
        if (secondRuckSack.Contains(letter) && thirdRuckSack.Contains(letter))
        {
            partTwoCommonItems.Add(letter);

            // score calculation
            partTwoPriorityScore += calculatePriorityScore(letter);
            break;
        }
    }
}

// Part 1 answer is 8202
// Part 2 answer is 2464
Console.WriteLine("For Part 1, the sum of the priorities is {0}.", partOnePriorityScore);
Console.WriteLine("For Part 2, the sum of the priorities is {0}.", partTwoPriorityScore);


watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();


static int calculatePriorityScore(char letter)
{
    // Lowercase item types a through z have priorities 1 through 26.
    // Uppercase item types A through Z have priorities 27 through 52.
    if (Char.IsLower(letter))
        return (letter - 'a' + 1);
    else
        return (letter - 'A' + 1 + 26);
}
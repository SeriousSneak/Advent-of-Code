// See https://aka.ms/new-console-template for more information

/* Advent of Code 2021
 * Day 10
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on October 20, 2022
 * Part 2 finished on October 21, 2022
 *
 * Project details
 *    Targeting .NET 6.0
 *    Created with Visual Studio 2022 on Windows 11 and Visual Studio 17 on MacOS 
 */


using System.Numerics;
using System.Security.Cryptography.X509Certificates;

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

// windows
string[] navSubsystem = File.ReadAllLines(@"C:\Temp\Drew's code repos\Advent-of-Code-2021\Day 10\input.txt");

// mac
//string[] lines = File.ReadAllLines(@"C:\Temp\Drew's code repos\Advent-of-Code-2021\Day 10\inputtest.txt");


// Part 1 
int partOneScore = 0;
List<double> partTwoScoreList = new List<double>();

//in the following loops, I'm using the List as a queue, adding items, and then removing them once the bracket has been closed.
for (int x = 0; x < navSubsystem.Length; x++)
{
    double partTwoLineScore = 0;
    char[] lineChars = navSubsystem[x].ToCharArray();
    List<char> brackets = new List<char>();

    for (int y = 0; y < lineChars.Length; y++)
    {
        if (y == 0 || lineChars[y] == '(' || lineChars[y] == '[' || lineChars[y] == '{' || lineChars[y] == '<')
        {
            brackets.Add(lineChars[y]);
        }
        else
        {
            switch (lineChars[y])
            {
                case ')':
                    if (brackets.Last() == '(')
                    {
                        brackets.RemoveAt(brackets.Count - 1);
                    }
                    else
                    {
                        Console.WriteLine("Line {0} is corrupted.", x);
                        partOneScore += partOneScoreDetermination(lineChars[y]); 
                        y = lineChars.Length;
                    }
                    break;

                case ']':
                    if (brackets.Last() == '[')
                    {
                        brackets.RemoveAt(brackets.Count - 1);
                    }
                    else
                    {
                        Console.WriteLine("Line {0} is corrupted.", x);
                        partOneScore += partOneScoreDetermination(lineChars[y]);
                        y = lineChars.Length;
                    }
                    break;

                case '}':
                    if (brackets.Last() == '{')
                    {
                        brackets.RemoveAt(brackets.Count - 1);
                    }
                    else
                    {
                        Console.WriteLine("Line {0} is corrupted.", x);
                        partOneScore += partOneScoreDetermination(lineChars[y]);
                        y = lineChars.Length;
                    }
                    break;

                case '>':
                    if (brackets.Last() == '<')
                    {
                        brackets.RemoveAt(brackets.Count - 1);
                    }
                    else
                    {
                        Console.WriteLine("Line {0} is corrupted.", x);
                        partOneScore += partOneScoreDetermination(lineChars[y]);
                        y = lineChars.Length;
                    }
                    break;

                default:
                    throw new Exception("We reached code that we should not have reached");
            }
        }

        // Part 2

        if (((lineChars.Length - 1) == y) && (brackets.Count != 0))   // if true then we have just evaluated the last character of the line and there are still brackets that have not yet been closed
        {
            Console.WriteLine("Line {0} is incomplete.", x);
            for (int count = brackets.Count - 1; count >= 0; count--)
            {
                partTwoLineScore = (partTwoLineScore * 5) + partTwoScoreDetermination(brackets[count]);
            }
            partTwoScoreList.Add(partTwoLineScore);
        }
    }
}

partTwoScoreList.Sort();

double partTwoScore = partTwoScoreList[(partTwoScoreList.Count / 2)]; //count will always be odd as noted in the puzzle description. This will find the value in the middle of the sorted list.


Console.WriteLine();
Console.WriteLine("Part 1: The total syntax error score is {0}.", partOneScore);
Console.WriteLine("Part 2: The total complete lines score is {0}.", partTwoScore);

watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();




static int partOneScoreDetermination(char illegalChar)
{
    switch(illegalChar)
    {
        case ')':
            return 3;
        
        case ']':
            return 57;

        case '}':
            return 1197;

        case '>':
            return 25137;

        default:
            throw new Exception("We reached code that we should not have reached");
    }
    
}
static int partTwoScoreDetermination(char closingBracket)
{
    switch(closingBracket)
    {
        case '(':
            return 1;

        case '[':
            return 2;

        case '{':
            return 3;

        case '<':
            return 4;

        default:
            throw new Exception("We reached code that we should not have reached");
    }
}
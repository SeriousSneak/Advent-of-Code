// See https://aka.ms/new-console-template for more information

/* Advent of Code 2022
 * Day 2
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on December 4, 2022
 * Part 2 finished on December 4, 2022
 *
 * Project details
 *    Targeting .NET 7.0
 *    Created with Visual Studio 2022 on Windows 11 and Visual Studio 17 on MacOS 
 */

using System.Globalization;

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

//Windows
string[] contents = File.ReadAllLines(@"C:\Temp\Repos\Advent-of-Code\C Sharp\2022\Day 02\input.txt");

//Mac
//string[] contents = File.ReadAllLines(@"/Users/andrew/Repos/Advent-of-Code/C Sharp/2022/Day 02/input.txt");

List<RockPaperScissors> stratGuide = new List<RockPaperScissors>();

foreach (string line in contents)
{
    RockPaperScissors rps = new RockPaperScissors(line[0], line[2]);
    stratGuide.Add(rps);
}

int partOneTotalScore = 0;
int partTwoTotalScore = 0;

for (int x = 0; x < stratGuide.Count; x++)
{
    int them = (stratGuide[x].them - 'A') + 1;
    int me = (stratGuide[x].me - 'X') + 1;

    /*
    With the above:
    1 = Rock
    2 = Paper
    3 = Scissors

    if I do "me minus them"
    
    Me winning:
    Scissors - Paper = 1
    Paper - Rock = 1
    Rock - Scissors = -2

    Them winning:
    Paper - Scissors = -1 
    Rock - Paper = -1
    Scissors - Rock = 2
    */

    // Part 2
    // 1 = lose
    // 2 = tie
    // 3 = win

    // Part 1
    if (me - them == 1 || me - them == -2) // I win
        partOneTotalScore += 6 + me;
    
    else if (me - them == -1 || me - them == 2) // I lose
        partOneTotalScore += me;
    
    else // This should only be hit if we hae a tie
        partOneTotalScore += 3 + me;

    // Part 2
    if (me == 1) // I need to lose
    {
        if (them == 1)
            partTwoTotalScore += 3;
        else
            partTwoTotalScore += (them - 1);
    }
    else if (me == 2) // I need to draw
    {
        partTwoTotalScore += (3 + them);
    }
    else // I need to win
    {
        if (them == 3)
            partTwoTotalScore += (1 + 6);
        else
            partTwoTotalScore += (them + 1 + 6);
    }
}


Console.WriteLine("For Part 1, the total score would be {0}.", partOneTotalScore);
Console.WriteLine("For Part 2, the total score would be {0}.", partTwoTotalScore);

watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();



public class RockPaperScissors
{
    public char them { get; set; }
    public char me { get; set; }

    // constructor
    public RockPaperScissors(char them, char me)
    {
        this.them = them;
        this.me = me;
    }

    public override bool Equals(object? obj)
    {
        if (this == obj)
            return true;
        if (obj == null)
            return false;

        RockPaperScissors rps = (RockPaperScissors)obj;
        return them == rps.them && me == rps.me;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}
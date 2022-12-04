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

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

//Windows
//string[] contents = File.ReadAllLines(@"C:\Temp\Repos\Advent-of-Code\C Sharp\2022\Day 01\input.txt");

//Mac
string[] contents = File.ReadAllLines(@"/Users/andrew/Repos/Advent-of-Code/C Sharp/2022/Day 02/input.txt");

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
    /* Part 1
    Them:
    A = Rock (1 point)
    B = Paper (2 points)
    C = Scissors (3 points)

    Me:
    X = Rock
    Y = Paper
    Z = Scissors

    Win is 6 points
    Draw is 3 points

    Part 2
    X = I need to lose
    Y = I need to tie
    Z = I need to win

    */

    // in the following calculations, (score based on what I throw, score if I win, tie, or lose)
    // Them: Rock & Me: Rock
    if (stratGuide[x].them == 'A' && stratGuide[x].me == 'X')
    {
        partOneTotalScore += (1 + 3);
        partTwoTotalScore += (3 + 0); // I throw scissors to lose 
    }

    // Them: Rock & Me: Paper
    if (stratGuide[x].them == 'A' && stratGuide[x].me == 'Y')
    {
        partOneTotalScore += (2 + 6);
        partTwoTotalScore += (1 + 3); // I throw rock to tie
    }

    // Them: Rock & Me: Scissors
    if (stratGuide[x].them == 'A' && stratGuide[x].me == 'Z')
    {
        partOneTotalScore += (3 + 0);
        partTwoTotalScore += (2 + 6); // I throw paper to win
    }

    // Them: Paper & Me: Rock
    if (stratGuide[x].them == 'B' && stratGuide[x].me == 'X')
    {
        partOneTotalScore += (1 + 0);
        partTwoTotalScore += (1 + 0); //I throw rock to lose
    }

    // Them: Paper & Me: Scissors
    if (stratGuide[x].them == 'B' && stratGuide[x].me == 'Z')
    {
        partOneTotalScore += (3 + 6);
        partTwoTotalScore += (3 + 6); // I throw scissors to win
    }

    // Them: Paper & Me: Paper
    if (stratGuide[x].them == 'B' && stratGuide[x].me == 'Y')
    {
        partOneTotalScore += (2 + 3);
        partTwoTotalScore += (2 + 3); // I throw paper to tie
    }

    // Them: Scissors & Me: Rock
    if (stratGuide[x].them == 'C' && stratGuide[x].me == 'X')
    {
        partOneTotalScore += (1 + 6);
        partTwoTotalScore += (2 + 0); // I throw paper to lose
    }

    // Them: Scissors & Me: Paper
    if (stratGuide[x].them == 'C' && stratGuide[x].me == 'Y')
    {
        partOneTotalScore += (2 + 0);
        partTwoTotalScore += (3 + 3); // I throw scissors to tie
    }

    // Them: Scissors & Me: Scissors
    if (stratGuide[x].them == 'C' && stratGuide[x].me == 'Z')
    {
        partOneTotalScore += (3 + 3);
        partTwoTotalScore += (1 + 6); // I throw rock to win
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
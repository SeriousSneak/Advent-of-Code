/* Advent of Code 2023
 * Day 2
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on February 09, 2024
 * Part 2 finished on February 09, 2024
 *
 * Project details
 *    Targeting .NET 8.0
 *    Created with Visual Studio 2022 on Windows 11
 */


var watch = new System.Diagnostics.Stopwatch();
watch.Start();

// Windows
string[] contents = File.ReadAllLines(@"C:\Temp\Repos\Advent-of-Code\C Sharp\2023\Day 02\input.txt");

// constants
int redConst = 12;
int greenConst = 13;
int blueConst = 14;
int gameNumber = 1;
int part1Answer = 0;
int part2Answer = 0;

// need to parse the input file
foreach (string line in contents)
{
    string[] stringSeparators = new string[] { ": ", ", "," " };
    string[] subStrings = line.Split(stringSeparators, StringSplitOptions.None);

    int red = 0;
    int green = 0;
    int blue = 0;
    int redMinimum = 0;
    int greenMinimum = 0;
    int blueMinimum = 0;
    int set = 1;
    bool gameIsPossible = true;  // we will assume the game will be possible until we get dadta showing that it isn't

    for (int x = 3; x < subStrings.Length; x+=2)
    {
        // colour names will be in odd cells starting at cell 3, and the number of them will be the cell before
        // Cell 0: "Game"
        // Cell 1: <Game number>
        // Cell 2: numer of balls of which colour is in Cell 3
        // Cell 4: number of balls of which colour is in cell 5

        switch (subStrings[x])
        {
            case "blue":
            case "blue;":
                blue += Convert.ToInt32(subStrings[x - 1]);
                if (blue > blueMinimum)
                {
                    blueMinimum = blue;
                }
                break;

            case "green":
            case "green;":
                green += Convert.ToInt32(subStrings[x - 1]);
                if (green > greenMinimum)
                {
                    greenMinimum = green;
                }
                break;

            case "red":
            case "red;":
                red += Convert.ToInt32(subStrings[x - 1]);
                if (red > redMinimum)
                {
                    redMinimum = red;
                }
                break;

            default:
                // We don't want to do anything if we have not encounted one of the above cases
                break;
        }
        if ((x == subStrings.Length - 1) || (subStrings[x].EndsWith(";")))
        {
            Console.WriteLine("Game {0} Set {1}: I found {2} blue, {3} green, and {4} red.", gameNumber, set, blue, green, red);
            if ((blue <= blueConst) && (green <= greenConst) && (red <= redConst))
            {
                Console.WriteLine("Game {0} Set {1} would have been possible.", gameNumber, set);
            }
            else
            {
                Console.WriteLine("Game {0} Set {1} would have been impossible.", gameNumber, set);
                gameIsPossible = false;
            }
            red = 0;
            green = 0;
            blue = 0;
            set++;
        }
    }

    if (gameIsPossible == true)
    {
        part1Answer += gameNumber;
    }

    Console.WriteLine("Game {0} minimum required is {1} blue, {2} green, and {3} red", gameNumber, blueMinimum, greenMinimum, redMinimum);

    part2Answer += (blueMinimum * greenMinimum * redMinimum);

    redMinimum = 0;
    greenMinimum = 0;
    blueMinimum = 0;
    
    gameNumber++;
    gameIsPossible = false;
    Console.WriteLine();
}                                                      


// For part 1 the answer is 2776
// For part 2 the answer is 68638

Console.WriteLine("For Part 1 the total sum of the possible game IDs is {0}.", part1Answer);
Console.WriteLine("For Part 2 the total sum is {0}.", part2Answer);


watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();

// See https://aka.ms/new-console-template for more information

/* Advent of Code 2019
 * Day 3
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on
 * Part 2 finished on
 *
 * Project details
 *    Targeting .NET 7.0
 *    Created with Visual Studio 2022 on Windows 11 and Visual Studio 17 on MacOS 
 */

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

//Mac
string[] contents = File.ReadAllLines(@"/Users/andrew/Temp/Advent-of-Code/C Sharp/2019/Day 03/inputtest.txt");


string[] wire1Directions = contents[0].Split(',');
string[] wire2Directions = contents[1].Split(',');



// Not sure how big my array needs to be. I'm going to start with 10000 x 10000 and then see if I get any out or bounds errors

string[,] map = new string[10000,10000];

// Fill every cell in the array with a "."
// I should not hard code 10000 below
for (int col = 0; col < 10000; col++)
{
    for (int row = 0; row < 10000; row++)
    {
        map[col, row] = ".";
    }
}

Point point = new Point(map.GetUpperBound(0)/2 ,map.GetUpperBound(1)/2); // starting point which is right in the middle of our array

map[point.col, point.row] = "O";


// adds a 1 to the map everywhere that the wire goes
foreach (string direction in wire1Directions)
{
    char whichWay = direction[0];
    int steps = Convert.ToInt32(direction.Remove(0, 1));

    switch (whichWay)
    {
        case 'U':
            break;

        case 'R':
            for (int x = 1; x <= steps; x++)
            {
                point.col++;
                map[point.col, point.row] = "1";
            }
            break;

        case 'D':
            break;

        case 'L':
            break;

        default:
            Console.WriteLine("Well crap, our switch statement found an unexpected direction.");
            break;
    }
}

// adds a 2 to the map everywhere that the wire goes, and will add an X if there is an existing 1, which will indicate the wires crossed at that point.
// instead of adding an X, I could also just calculate the manhattan distance from the starting point to that point
foreach (string direction in wire2Directions)
{

}


watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();






public class Point
{
    public int row { get; set; }
    public int col { get; set; }

    // constructor
    public Point(int col, int row)
    {
        this.row = row;
        this.col = col;
    }

    public override bool Equals(object? obj)
    {
        if (this == obj)
            return true;
        if (obj == null)
            return false;

        Point point = (Point)obj;
        return col == point.col && row == point.row;
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
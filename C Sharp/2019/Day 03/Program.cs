// See https://aka.ms/new-console-template for more information

/* Advent of Code 2019
 * Day 3
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on December 1, 2022
 * Part 2 finished on December 1, 2022
 *
 * Project details
 *    Targeting .NET 7.0
 *    Created with Visual Studio 2022 on Windows 11 and Visual Studio 17 on MacOS 
 */

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

//Windows
//string[] contents = File.ReadAllLines(@"C:\Temp\Repos\Advent-of-Code\C Sharp\2019\Day 03\input.txt");

//Mac
string[] contents = File.ReadAllLines(@"/Users/andrew/Repos/Advent-of-Code/C Sharp/2019/Day 03/inputtest.txt");



string[] wire1Directions = contents[0].Split(',');
string[] wire2Directions = contents[1].Split(',');

List<Point> wire1Points = new List<Point>();
List<Point> wire2Points = new List<Point>();

Point point = new Point(0 ,0); // starting point

// create a list of all points that the first wire passes through
foreach (string direction in wire1Directions)
{
    char whichWay = direction[0];
    int steps = Convert.ToInt32(direction.Remove(0, 1));

    switch (whichWay)
    {
        case 'U':
            for (int y = 1; y <= steps; y++)
            {
                point.y++;
                Point tempPoint = new Point(point.x, point.y);
                wire1Points.Add(tempPoint);
            }
            break;

        case 'R':
            for (int x = 1; x <= steps; x++)
            {
                point.x++;
                Point tempPoint = new Point(point.x, point.y);
                wire1Points.Add(tempPoint);
            }
            break;

        case 'D':
            for (int y = 1; y <= steps; y++)
            {
                point.y--;
                Point tempPoint = new Point(point.x, point.y);
                wire1Points.Add(tempPoint);
            }
            break;

        case 'L':
            for (int x = 1; x <= steps; x++)
            {
                point.x--; Point tempPoint = new Point(point.x, point.y);
                wire1Points.Add(tempPoint);
            }
            break;

        default:
            Console.WriteLine("Well crap, our switch statement found an unexpected direction.");
            break;
    }
}

// reset our starting point now that we are going to map out the second wire
point.x = 0;
point.y = 0;

// create a list of all points that the second wire passes through
foreach (string direction in wire2Directions)
{
    char whichWay = direction[0];
    int steps = Convert.ToInt32(direction.Remove(0, 1));

    switch (whichWay)
    {
        case 'U':
            for (int y = 1; y <= steps; y++)
            {
                point.y++;
                Point tempPoint = new Point(point.x, point.y);
                wire2Points.Add(tempPoint);
            }
            break;

        case 'R':
            for (int x = 1; x <= steps; x++)
            {
                point.x++;
                Point tempPoint = new Point(point.x, point.y);
                wire2Points.Add(tempPoint);
            }
            break;

        case 'D':
            for (int y = 1; y <= steps; y++)
            {
                point.y--;
                Point tempPoint = new Point(point.x, point.y);
                wire2Points.Add(tempPoint);
            }
            break;

        case 'L':
            for (int x = 1; x <= steps; x++)
            {
                point.x--;
                Point tempPoint = new Point(point.x, point.y);
                wire2Points.Add(tempPoint);
            }
            break;

        default:
            Console.WriteLine("Well crap, our switch statement found an unexpected direction.");
            break;
    }
}



// find the Points that are common between the two lists
int manhattanDistance = int.MaxValue;
int totalSteps = int.MaxValue;
for (int x = 0; x < wire1Points.Count; x++)
{
    double percentageComplete = ((double)x / (double)wire1Points.Count) * 100;
    Console.CursorVisible = false;
    Console.WriteLine("Analyzing point {0} out of {1}", x, wire1Points.Count);
    Console.WriteLine("Progress: {0}%", percentageComplete.ToString("F"));
    Console.SetCursorPosition(0, Console.CursorTop - 2);

    if (wire2Points.Contains(wire1Points[x]))
    {
        // Part 1 - calculate the manhattan distances to find the smallest ones
        if ((Math.Abs(wire1Points[x].x) + Math.Abs(wire1Points[x].y)) < manhattanDistance)
        {
            manhattanDistance = Math.Abs(wire1Points[x].x) + Math.Abs(wire1Points[x].y);
        }
        
        // Part 2 - find the point that the wires cross where the steps that each wire takes to get there is the lowest out of all points they cross
        // we need to add 1 to each of these as the first step is recorded in position 0 of the array
        int wire1Steps = wire1Points.IndexOf(wire1Points[x]) + 1;
        int wire2Steps = wire2Points.IndexOf(wire1Points[x]) + 1;

        if ((wire1Steps + wire2Steps) < totalSteps)
        {
            totalSteps = wire1Steps + wire2Steps;
        }

    }
}

// Part 1 answer is 225. Run time was 544272ms / 9 minutes.
// Part 2 answer is 35194.

Console.CursorVisible = true;
Console.WriteLine("For Part 1, the shortest Manhattan Distance is {0}", manhattanDistance);
Console.WriteLine("For Part 2, total shortest steps are {0}.", totalSteps);


watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();


public class Point
{
    public int x { get; set; }
    public int y { get; set; }

    // constructor
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object? obj)
    {
        if (this == obj)
            return true;
        if (obj == null)
            return false;

        Point point = (Point)obj;
        return x == point.x && y == point.y;
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
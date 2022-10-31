// See https://aka.ms/new-console-template for more information

/* Advent of Code 2021
 * Day 11
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on October 26, 2022
 * Part 2 finished on October 26, 2022
 *
 * Project details
 *    Targeting .NET 6.0
 *    Created with Visual Studio 2022 on Windows 11 and Visual Studio 17 on MacOS 
 */

using System.Runtime.CompilerServices;

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

// windows
//var lines = File.ReadAllLines(@"C:\Temp\Repos\Advent-of-Code-2021\Day 11\inputtest_large.txt");

// mac
var lines = File.ReadLines(@"/Users/andrew/Temp/Advent-of-Code-2021/Day 11/input.txt");

int colCount = lines.ElementAt(0).Count();
int rowCount = lines.Count();   // counts the number of elements, which is the number of rows
int currentLine = 0;
int numberOfFlashes = 0;
int steps = 0;
bool allFlashedSimultaneously = false;


int[,] data = new int[colCount, rowCount];

foreach (var line in lines)
{
    for (int rowDigit = 0; rowDigit < colCount; rowDigit++)
    {
        data[rowDigit, currentLine] = int.Parse(line[rowDigit].ToString());
    }
    currentLine++;
}

Console.WriteLine("Before any steps:");
printArray(data);

// y is which row I'm on
// x is which column I'm on

// the first for loop will control hope many steps we take. I got rid of this for part 2, but still account for the first 100 steps when calculating the answer to part 1.
//for (int steps = 1; steps <= 1000; steps++)
while (allFlashedSimultaneously == false)
{
    steps++;
    List<OurPoint> newFlashToProcess = new List<OurPoint>();
    List<OurPoint> haveFlashed = new List<OurPoint>();

    for (int y = 0; y < rowCount; y++)
    {
        for (int x = 0; x < colCount; x++)
        {
            OurPoint currentPoint = new OurPoint(x, y);
            data[x, y]++;
            if (data[x, y] == 10)
            {
                data[x, y] = 0;
                newFlashToProcess.Add(currentPoint);  // record that we have a flash and who has flashed
                haveFlashed.Add(currentPoint);
            }
        }
    }

    Console.WriteLine();
    Console.WriteLine("Data after incrementing everything by one:");
    printArray(data);

    // process the ones that have flashed, and increase the ones around them
    while (newFlashToProcess.Count > 0)
    {
        OurPoint currentPoint = newFlashToProcess[0];
        newFlashToProcess.RemoveAt(0);

        // check number north
        OurPoint north = new OurPoint(currentPoint.col, currentPoint.row - 1);
        if ((currentPoint.row > 0) && (!haveFlashed.Contains(north)))
        {
            data[north.col, north.row]++;

            if (data[north.col, north.row] == 10)
            {
                data[north.col, north.row] = 0;
                newFlashToProcess.Add(north);
                haveFlashed.Add(north);
            }
        }

        // check number north east
        OurPoint northEast = new OurPoint(currentPoint.col + 1, currentPoint.row - 1);
        if ((currentPoint.row > 0) && (currentPoint.col < (colCount - 1)) && (!haveFlashed.Contains(northEast)))
        {
            data[northEast.col, northEast.row]++;

            if (data[northEast.col, northEast.row] == 10)
            {
                data[northEast.col, northEast.row] = 0;
                newFlashToProcess.Add(northEast);
                haveFlashed.Add(northEast);
            }
        }

        // check number east
        OurPoint east = new OurPoint(currentPoint.col + 1, currentPoint.row);
        if ((currentPoint.col < (colCount - 1)) && (!haveFlashed.Contains(east)))
        {
            data[east.col, east.row]++;

            if (data[east.col, east.row] == 10)
            {
                data[east.col, east.row] = 0;
                newFlashToProcess.Add(east);
                haveFlashed.Add(east);
            }
        }

        // check number south east
        OurPoint southEast = new OurPoint(currentPoint.col + 1, currentPoint.row + 1);
        if ((currentPoint.row < (rowCount - 1)) && (currentPoint.col < (colCount - 1)) && (!haveFlashed.Contains(southEast)))
        {
            data[southEast.col, southEast.row]++;

            if (data[southEast.col, southEast.row] == 10)
            {
                data[southEast.col, southEast.row] = 0;
                newFlashToProcess.Add(southEast);
                haveFlashed.Add(southEast);
            }
        }

        // check number south
        OurPoint south = new OurPoint(currentPoint.col, currentPoint.row + 1);
        if ((currentPoint.row < (rowCount - 1)) && (!haveFlashed.Contains(south)))
        {
            data[south.col, south.row]++;

            if (data[south.col, south.row] == 10)
            {
                data[south.col, south.row] = 0;
                newFlashToProcess.Add(south);
                haveFlashed.Add(south);
            }
        }


        // check number south west
        OurPoint southWest = new OurPoint(currentPoint.col - 1, currentPoint.row + 1);
        if ((currentPoint.row < (rowCount - 1)) && (currentPoint.col > 0) && (!haveFlashed.Contains(southWest)))
        {
            data[southWest.col, southWest.row]++;

            if (data[southWest.col, southWest.row] == 10)
            {
                data[southWest.col, southWest.row] = 0;
                newFlashToProcess.Add(southWest);
                haveFlashed.Add(southWest);
            }
        }

        // check number west
        OurPoint west = new OurPoint(currentPoint.col - 1, currentPoint.row);
        if ((currentPoint.col > 0) && (!haveFlashed.Contains(west)))
        {
            data[west.col, west.row]++;

            if (data[west.col, west.row] == 10)
            {
                data[west.col, west.row] = 0;
                newFlashToProcess.Add(west);
                haveFlashed.Add(west);
            }
        }

        // check number north west
        OurPoint northWest = new OurPoint(currentPoint.col - 1, currentPoint.row - 1);
        if ((currentPoint.row > 0) && (currentPoint.col > 0) && (!haveFlashed.Contains(northWest)))
        {
            data[northWest.col, northWest.row]++;

            if (data[northWest.col, northWest.row] == 10)
            {
                data[northWest.col, northWest.row] = 0;
                newFlashToProcess.Add(northWest);
                haveFlashed.Add(northWest);
            }
        }

        //Console.WriteLine();
        //printArray(data);

    }
    Console.WriteLine();
    Console.WriteLine("After step {0}:", steps);
    printArray(data);

    // For part 1, we only want to count the number of flashes seen in the first 100 steps
    if (steps <= 100)
    {
        numberOfFlashes += haveFlashed.Count;
    }

    allFlashedSimultaneously = checkSimultaneousFlash(data);


}


// part 1 answer is 1755
// part 2 answer is

Console.WriteLine();
Console.WriteLine("There were a total of {0} flashes.", numberOfFlashes);
Console.WriteLine("All octopuses flashed simultaneously after step {0}", steps);


watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();



static bool checkSimultaneousFlash(int[,] passedArray)
{
    for (int row = 0; row < passedArray.GetLength(1); row++)
    {
        for (int col = 0; col < passedArray.GetLength(0); col++)
        {
            if (passedArray[col, row] != 0)
            {
                return false;
            }
        }
    }
    return true;
}


static void printArray(int[,] passedArray)
{
    for (int row = 0; row < passedArray.GetLength(1); row++)
    {
        for (int col = 0; col < passedArray.GetLength(0); col++)
        {
            Console.Write(passedArray[col, row]);
        }
        Console.WriteLine();
    }
}

public class OurPoint
{
    public int row { get; set; }
    public int col { get; set; }

    // constructor
    public OurPoint(int col, int row)
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

        OurPoint point = (OurPoint)obj;
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
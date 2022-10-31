// See https://aka.ms/new-console-template for more information

/* Advent of Code 2021
 * Day 9
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on October 12, 2022
 * Part 2 finished on October 14, 2022
 *
 * Project details
 *    Targeting .NET 6.0
 *    Created with Visual Studio 2022 on Windows 11 and Visual Studio 17 on MacOS 
 */

using System.Drawing;
using System.Collections;

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

// windows
var lines = File.ReadLines(@"C:\Temp\Drew's code repos\Advent-of-Code-2021\Day 9\input.txt");

// mac
//var lines = File.ReadLines(@"/Users/andrew/Temp/Advent-of-Code-2021/Day 9/input.txt");

int rowCount = lines.Count();
string firstRow = lines.First();
int colCount = firstRow.Length;

int[,] heightMap = new int[colCount, rowCount];

int currentLine = 0;
int riskLevelSum = 0;
int numberOfLowPoints = 0;
List<OurPoint> lows = new List<OurPoint>();

// fill up our int array with the input
foreach (var line in lines)
{
    for (int rowDigit = 0; rowDigit < colCount; rowDigit++)
    {
        heightMap[rowDigit, currentLine] = int.Parse(line[rowDigit].ToString());
    }
    currentLine++;
}

Console.WriteLine("The following is the input with the low points highlighted.");

// Part 1
for (int row = 0; row < rowCount; row++)
{
    for (int col = 0; col < colCount; col++)
    {
        int currentNumber = heightMap[col, row];

        //The following IF statements could be made much cleaner if I wasn't writing out the Input to the Console

        // check number above
        if ((row - 1) >= 0 && heightMap[col, row] >= heightMap[col, (row - 1)])
        {
            if (col == 0)
            {
                Console.WriteLine("");
            }
            Console.Write("{0}", currentNumber);
            continue;
        }

        // check number to the right
        if ((col + 1) < colCount && heightMap[col, row] >= heightMap[(col + 1), row])
        {
            if (col == 0)
            {
                Console.WriteLine("");
            }
            Console.Write("{0}", currentNumber);
            continue;
        }

        // check number to the bottom
        if ((row + 1) < rowCount && heightMap[col, row] >= heightMap[col, (row + 1)])
        {
            if (col == 0)
            {
                Console.WriteLine("");
            }
            Console.Write("{0}", currentNumber);
            continue;
        }
        // check number to the left
        if ((col - 1) >= 0 && heightMap[col, row] >= heightMap[(col - 1), row])
        {
            if (col == 0)
            {
                Console.WriteLine("");
            }
            Console.Write("{0}", currentNumber);
            continue;
        }

        // do stuff if we have found a low point        
        lows.Add(new OurPoint(col, row));
        riskLevelSum += heightMap[col, row] + 1;
        numberOfLowPoints++;

        if (col == 0)
        {
            Console.WriteLine("");
        }

        // save the previous colour
        var prevColour = Console.ForegroundColor;

        // set your colour
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("{0}", currentNumber);

        // restore old text's colour
        Console.ForegroundColor = prevColour;
    }
}


// Part 2
// Here I'm doing a Breadth First Search, but instead of using a Queue I'm using a List for the queue.
// I coded this after watching https://www.youtube.com/watch?v=QxTETjIj80k / https://github.com/TheTurkeyDev/Advent-of-Code-2021
List<long> largest = new List<long>();
foreach (OurPoint p in lows)
{
    long size = 0;
    List<OurPoint> visited = new List<OurPoint>();
    List<OurPoint> toVisit = new List<OurPoint>();

    toVisit.Add(p);

    while (toVisit.Count > 0)
    {
        OurPoint nextPoint = toVisit[0];
        toVisit.RemoveAt(0);

        if (visited.Contains(nextPoint))
            continue;

        size++;
        visited.Add(nextPoint);
        int row = nextPoint.row;
        int col = nextPoint.col;

        // check number above
        if (((row - 1) >= 0) && (heightMap[col, (row - 1)] != 9))
        {
            OurPoint up = new OurPoint(col, row - 1);
            if (!visited.Contains(up))
            {
                toVisit.Add(up);
            }
        }

        // check number to the right
        if (((col + 1) < colCount) && (heightMap[(col + 1), row] != 9))
        {
            OurPoint right = new OurPoint(col + 1, row);
            if (!visited.Contains(right))
            {
                toVisit.Add(right);
            }
        }

        // check number to the bottom
        if (((row + 1) < rowCount) && (heightMap[col, (row + 1)] != 9))
        {
            OurPoint down = new OurPoint(col, row + 1);
            if (!visited.Contains(down))
            {
                toVisit.Add(down);
            }
        }

        // check number to the left
        if (((col - 1) >= 0) && (heightMap[(col - 1), row] != 9))
        {
            OurPoint left = new OurPoint(col - 1, row);
            if (!visited.Contains(left))
            {
                toVisit.Add(left);
            }
        }
    }

    if (largest.Count < 3)
    {
        largest.Add(size);
    }
    else
    {
        for (int i = 0; i < 3; i++)
        {
            if (largest[i] < size)
            {
                largest[i] = size;
                break;
            }
        }
    }
}

long part2Answer = largest[0] * largest[1] * largest[2];

//Part 1 answer is 566
//Part 2 answer is 891684
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("We found {0} low points", numberOfLowPoints);
Console.WriteLine("The answer for Part 1 is: {0}.", riskLevelSum);
Console.WriteLine("The answer for Part 2 is: {0}.", part2Answer);


watch.Stop();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine("");
Console.WriteLine("Press any key to continue.");
Console.ReadKey();



public class OurPoint
{
    public int row;
    public int col;
    
    public OurPoint(int col, int row)
    {
        this.row = row;
        this.col = col;
    }

    public override bool Equals(object? obj)
    {
        if(this == obj)
            return true;
        if (obj == null)
            return false;

        OurPoint point = (OurPoint)obj;
        return col == point.col && row == point.row;    
        //return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString()
    {
        return ("Point" + col.ToString() + "," + row.ToString());
        //return base.ToString();
    }
}

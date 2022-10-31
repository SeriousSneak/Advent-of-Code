// See https://aka.ms/new-console-template for more information

/* Advent of Code 2021
 * Day 3
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on December 5, 2021
 * Part 2 finished on December 6, 2021.
 *
 * Project details
 *    Targeting .NET 6.0
 *    Created with Visual Studio 2022 on Windows 11 and Visual Studio 17 on MacOS 
 */

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

// windows
//var lines = File.ReadLines(@"C:\Temp\Drew's code repos\Advent-of-Code-2021\Day 3\input.txt");

// mac
var lines = File.ReadLines(@"/Users/andrew/Temp/Advent-of-Code-2021/Day 3/input.txt");

// Part 1
var linesList = new List<string>(lines);

string gammaRate = "";
string epsilonRate = "";

int numLength = linesList[0].Length;
int totalNumbers = linesList.Count;

string[,] stringArray = new string[totalNumbers, numLength];

//create an array with each digit in a single cell
for (int row = 0; row < totalNumbers; row++)
{
    for (int col = 0; col < numLength; col++)
    {
        stringArray[row, col] = linesList[row].Substring(col, 1);
    }
}


// find gamma rate and epsilon rate
for (int col = 0; col < numLength; col++)
{
    int countOnes = 0;
    int countZeros = 0;

    for (int row = 0; row < totalNumbers; row++)
    {
        if (stringArray[row, col] == "0")
        {
            countZeros++;
        }
        else
        {
            countOnes++; ;
        }
    }

    if (countZeros > countOnes)
    {
        gammaRate = gammaRate + "0";
        epsilonRate = epsilonRate + "1";
    }
    else
    {
        gammaRate = gammaRate + "1";
        epsilonRate = epsilonRate + "0";
    }


}

int gammaInt = Convert.ToInt32(gammaRate, 2);
int epsilonInt = Convert.ToInt32(epsilonRate, 2);


Console.WriteLine("Part 1: Gamma rate: " + gammaRate + " (" + gammaInt + ")");
Console.WriteLine("Part 1: Epsilon rate: " + epsilonRate + " (" + epsilonInt + ")");

int totalPowerConsumption = gammaInt * epsilonInt;

Console.WriteLine("Part 1: Total Power Consumption (Gamma rate x Epsilon rate = " + totalPowerConsumption);

Console.WriteLine("");





// Part 2
// I will be taking destrucive actions on the list, and so I've created two of them. One to figure out the Oxygen rating, and the other to figure out the CO2 rating
var linesListOxygen = new List<string>(lines);
var linesListCO2 = new List<string>(lines);


int numLengthOxygen = linesListOxygen[0].Length;
int totalNumbersOxygen = linesListOxygen.Count;

int numLengthCO2 = linesListCO2[0].Length;
int totalNumbersCO2 = linesListCO2.Count;


// Determine Oxygen Generator Rating
for (int col = 0; col < numLengthOxygen; col++)
{
    int countOnes = 0;
    int countZeros = 0;

    for (int row = 0; row < totalNumbersOxygen; row++)
    {
        if (linesListOxygen[row].Substring(col, 1) == "0")
        {
            countZeros++;
        }
        else
        {
            countOnes++;
        }
    }

    // if countOnes > countZeros, keep number if start with one
    // if countOnes == countZeros, keep number if start with one
    // if countZeros > countOnes, keep number if start with zero                      
    for (int row = 0; row < totalNumbersOxygen; row++)
    {
        if ((countZeros == countOnes) || (countZeros < countOnes)) //keep numbers that start with one
        {
            if (linesListOxygen[row].Substring(col, 1) == "0")
            {
                linesListOxygen.RemoveAt(row);
                row--;
            }
        }
        else if (countZeros > countOnes) //keep numbers that start with zero
        {
            if (linesListOxygen[row].Substring(col, 1) == "1")
            {
                linesListOxygen.RemoveAt(row);
                row--;
            }
        }
        totalNumbersOxygen = linesListOxygen.Count;

        if (totalNumbersOxygen == 1)  //break out of loop
        {
            row = totalNumbersOxygen + 1;
            col = numLengthOxygen + 1;
        }
    }
}


// Determine CO2 Scrubber Rating
for (int col = 0; col < numLengthCO2; col++)
{
    int countOnes = 0;
    int countZeros = 0;

    for (int row = 0; row < totalNumbersCO2; row++)
    {
        if (linesListCO2[row].Substring(col, 1) == "0")
        {
            countZeros++;
        }
        else
        {
            countOnes++;
        }
    }

    // if countOnes > countZeros, keep number if start with zero
    // if countOnes == countZeros, keep number if start with zero
    // if countZeros > countOnes, keep number if start with one                      
    for (int row = 0; row < totalNumbersCO2; row++)
    {
        if ((countZeros == countOnes) || (countZeros < countOnes)) //keep numbers that start with zero
        {
            if (linesListCO2[row].Substring(col, 1) == "1")
            {
                linesListCO2.RemoveAt(row);
                row--;
            }
        }
        else if (countZeros > countOnes) //keep numbers that start with one
        {
            if (linesListCO2[row].Substring(col, 1) == "0")
            {
                linesListCO2.RemoveAt(row);
                row--;
            }
        }
        totalNumbersCO2 = linesListCO2.Count;

        if (totalNumbersCO2 == 1)  //break out of loop
        {
            row = totalNumbersCO2 + 1;
            col = numLengthCO2 + 1;
        }
    }
}

int oxygenInt = Convert.ToInt32(linesListOxygen[0], 2);
int CO2Int = Convert.ToInt32(linesListCO2[0], 2);

Console.WriteLine("Part 2: Oxygen Generator Rating: " + linesListOxygen[0] + "(" + oxygenInt + ")");
Console.WriteLine("Part 2: CO2 Scrubber Rating: " + linesListCO2[0] + "(" + CO2Int + ")");

int lifeSupportRating = oxygenInt * CO2Int;


Console.WriteLine("Part 2: The Life Support Rating is (Oxygen Generator Rating * CO2 Scrubber Rating = " + lifeSupportRating);


watch.Stop();
Console.WriteLine("");
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine("");
Console.WriteLine("Press any key to continue.");
Console.ReadKey();
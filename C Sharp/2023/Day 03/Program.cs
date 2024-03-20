/* Advent of Code 2023
 * Day 3
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on
 * Part 2 finished on
 *
 * Project details
 *    Targeting .NET 8.0
 *    Created with Visual Studio 2022 on Windows 11
 */


var watch = new System.Diagnostics.Stopwatch();
watch.Start();

// Read all lines from the text file
string[] lines = File.ReadAllLines("C:\\_Temp\\Repos\\Advent-of-Code\\C Sharp\\2023\\Day 03\\inputTest.txt");

// Determine the maximum line length (number of columns)
int maxLineLength = lines.Max(line => line.Length);

// Initialize the 2D array
char[,] charArray = new char[lines.Length, maxLineLength];

// Populate the 2D array
for (int row = 0; row < lines.Length; row++)
{
    char[] lineCharacters = lines[row].ToCharArray();
    for (int col = 0; col < lineCharacters.Length; col++)
    {
        charArray[row, col] = lineCharacters[col];
    }
}

// 2D array format is [row,col]. So the first line is [0,0],[0,1],[0,2],[0,3] etc.

/*
 * Read line 1, 1 char at a time. If we find a number, store in a string and check to see if there is an adjacent character that is not a number or a period. 
 * If we find one, set a flag. Read the next char, if a number and if flag set, keep reading. Once we find a period, if the flag is set, add the number to our main counter
 */

/*
// Two-dimensional GetLength example.
int[,] two = new int[5, 10];
Console.WriteLine(two.GetLength(0)); // Writes 5
Console.WriteLine(two.GetLength(1)); // Writes 10
*/

string number = "";
int sum;
bool foundAdjacent = false;

for (int row = 0; row < charArray.GetLength(0); row++)
{
    for (int col = 0; col < charArray.GetLength(1); col++)
    {
        if (Char.IsDigit(charArray[row, col]))
        {
            number += charArray[row, col]; //add the number to the end of the string

            // check to see if there is an adjacent character that is not a number or a period
        }
        else
        {
            // if flag is set
            //   add number to the sum
            //   clear number

            // if flag is not set
            //   clear number
        }

    }
}





watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();
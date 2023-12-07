// See https://aka.ms/new-console-template for more information


/* Advent of Code 2023
 * Day 1
 * 
 * Programmer: Andrew Stobart
 * Part 1 finished on December 6, 2023
 * Part 2 finished on 
 *
 * Project details
 *    Targeting .NET 8.0
 *    Created with Visual Studio 2022 on Windows 11
 */


using System.ComponentModel.Design;

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

// Windows
string[] contents = File.ReadAllLines(@"C:\Temp\Repos\Advent-of-Code\C Sharp\2023\Day 01\input.txt");


// Part 1

double firstNum = 0;
double secondNum = 0;
double part1TotalSum = 0;


for (int x = 0; x < contents.Length; x++)
{
    bool isFirstNumber = true;
    foreach (char c in contents[x])
    {
        if(c >= '0' && c <= '9')   // will be true if the character is a number
        {
            if (isFirstNumber == true)  
            {
                firstNum = Char.GetNumericValue(c);
                secondNum = Char.GetNumericValue(c);
                isFirstNumber = false;
            }
            else
            {
                secondNum = Char.GetNumericValue(c);
            }
        }
    }
    part1TotalSum += (firstNum * 10 + secondNum);
}


// Part 2

firstNum = 0;
secondNum = 0;
string wordNumber = "";
double foundNumber = -1;
double part2TotalSum = 0;
int entry = 1;

for (int x = 0; x < contents.Length; x++)
{
    bool isFirstNumber = true;
    foreach (char c in contents[x])
    {
        if(c >= '0' && c <='9')   // will be true if the character is a number
        {
            if (isFirstNumber == true)
            {
                firstNum = Char.GetNumericValue(c);
                secondNum = Char.GetNumericValue(c);
                isFirstNumber = false;
            }
            else
            {
                secondNum = Char.GetNumericValue(c);
            }
            wordNumber = "";
        }
        else   // we will hit the else if the character is not a number
        {
            wordNumber += c;

            if (wordNumber.Contains("zero"))
            {
                foundNumber = 0;
            }
            else if (wordNumber.Contains("one"))
            {
                foundNumber = 1;
            }
            else if (wordNumber.Contains("two"))
            {
                foundNumber = 2;
            }
            else if (wordNumber.Contains("three"))
            {
                foundNumber = 3;
            }
            else if (wordNumber.Contains("four"))
            {
                foundNumber = 4;
            }
            else if (wordNumber.Contains("five"))
            {
                foundNumber = 5;
            }
            else if (wordNumber.Contains("six"))
            {
                foundNumber = 6;
            }
            else if (wordNumber.Contains("seven"))
            {
                foundNumber = 7;
            }
            else if (wordNumber.Contains("eight"))
            {
                foundNumber = 8;
            }
            else if (wordNumber.Contains("nine"))
            {
                foundNumber = 9;
            }


            if (foundNumber != -1)   // we found a word number
            {
                if (isFirstNumber == true)
                {
                    firstNum = foundNumber;
                    secondNum = foundNumber;
                    isFirstNumber = false;
                }
                else
                {
                    secondNum = foundNumber;
                }
                foundNumber = -1;
                wordNumber = "";
            }
        }
    }
    Console.WriteLine("Entry " + entry + ": " + firstNum + "" + secondNum);
    entry++;
    part2TotalSum += (firstNum * 10 + secondNum);
}

// 54095 is too low for part 2

// Line 231: one5thcfourndbphpxszjmt7eightwof
// My code says 18, but real answer is 12. I need to account for numbers that have overlapping letters like eightwo. Maybe I need to read from the right to find the second digit?

Console.WriteLine("For Part 1 the total sum is {0}.", part1TotalSum);
Console.WriteLine("For Part 2 the total sum is {0}.", part2TotalSum);


watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine();
Console.WriteLine("Press any key to continue.");
Console.ReadKey();
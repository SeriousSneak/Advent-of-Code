// See https://aka.ms/new-console-template for more information
/* Advent of Code 2021
 * 
 * Programmer: Andrew Stobart
 * Date: 
 *
 * Project details
 *    Targeting .NET 6.0
 *    Created with Visual Studio 2022 on Windows 11 and MacOS
 *
 * Day 8 Part 2
 * 
 * 
 * NOTES
 * 
 * I coded this solution based on https://www.reddit.com/r/adventofcode/comments/rc5s3z/2021_day_8_part_2_a_simple_fast_and_deterministic/.
 * 
 * 
 *   0:      1:      2:      3:      4:
 *  aaaa    ....    aaaa    aaaa    ....
 * b    c  .    c  .    c  .    c  b    c
 * b    c  .    c  .    c  .    c  b    c
 *  ....    ....    dddd    dddd    dddd
 * e    f  .    f  e    .  .    f  .    f
 * e    f  .    f  e    .  .    f  .    f
 *  gggg    ....    gggg    gggg    ....
 * 
 *   5:      6:      7:      8:      9:
 *  aaaa    aaaa    aaaa    aaaa    aaaa
 * b    .  b    .  .    c  b    c  b    c
 * b    .  b    .  .    c  b    c  b    c
 *  dddd    dddd    ....    dddd    dddd
 * .    f  e    f  .    f  e    f  .    f
 * .    f  e    f  .    f  e    f  .    f
 *  gggg    gggg    ....    gggg    gggg
 * 
 * 
 * Count the number of times each segment appears, this will be the segments weight.
 * 
 *  Segment Scoring:
 *  SegA: 8
 *  SegB: 6
 *  SegC: 8
 *  SegD: 7
 *  SegE: 4
 *  SegF: 9
 *  SegG: 7
 * 
 * 
 * For each digit, calculate it's score by adding the weights of all segments that are required to create it.
 * 
 * 0: 42 a(8)b(6)c(8)e(4)f(9)g(7)
 * 1: 17 c(8)f(9)
 * 2: 34 a(8)c(8)d(7)e(4)g(7)
 * 3: 39 a(8)c(8)d(7)f(9)g(7)
 * 4: 30 b(6)c(8)d(7)f(9)
 * 5: 37 a(8)b(6)d(7)f(9)g(7)
 * 6: 41 a(8)b(6)d(7)e(4)f(9)g(7)
 * 7: 25 a(8)c(8)f(9)
 * 8: 49 a(8)b(6)c(8)d(7)e(4)f(9)g(7)
 * 9: 45 a(8)b(6)c(8)d(7)f(9)g(7)
 * 
 * We can now use the above to figure out the scrambled digits.
 * 
 * 
 * Example:
 * 
 * (to the left of the | are numbers 0-9, but not in that order and the segments are scrambed. To the right of the | we have 4 random digits
 * acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf

 * Count of letters to the left of the |:
 * A: 8
 * B: 9
 * C: 7
 * D: 8
 * E: 6
 * F: 7
 * G: 4

 * Using the above counts, find the sum for each of the digits to the right of the |. Then compare this to the calculations I did above.
cdfeb = 7+8+7+6+9 = 37 = 5
fcadb = 7+7+8+8+9 = 39 = 3
cdfeb = 7+8+7+6+9 = 37 = 5
cdbaf = 7+8+9+8+7 = 39 = 3
 * 
 */

var watch = new System.Diagnostics.Stopwatch();
watch.Start();


//windows
var lines = File.ReadLines(@"C:\Temp\Drew's code repos\Advent-of-Code-2021\Day 8\Part 2\input.txt");

//mac
//var lines = File.ReadLines(@"/Users/andrew/Temp/Advent-of-Code-2021/Day 8/Part 2/input.txt");

double totalSum = 0;

foreach (var line in lines)
{
    string[] stringSeparators = new string[] { " ", "|" };
    string[] subStrings = line.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

    Dictionary<char, int> segmentCounts = new Dictionary<char, int>();
    segmentCounts.Add('a', 0);
    segmentCounts.Add('b', 0);
    segmentCounts.Add('c', 0);
    segmentCounts.Add('d', 0);
    segmentCounts.Add('e', 0);
    segmentCounts.Add('f', 0);
    segmentCounts.Add('g', 0);

    int[] digit = new int[4];

    //find the number of times each letter appears. 0 looks for A, 1 looks for B, etc...
    for (int loop = 0; loop < 14; loop++)
    {
        //dealing with numbers to the left of the |
        if (loop < 10)
        {
            if (subStrings[loop].Contains('a'))
            {
                segmentCounts['a']++;
            }
            if (subStrings[loop].Contains('b'))
            {
                segmentCounts['b']++;
            }
            if (subStrings[loop].Contains('c'))
            {
                segmentCounts['c']++;
            }
            if (subStrings[loop].Contains('d'))
            {
                segmentCounts['d']++;
            }
            if (subStrings[loop].Contains('e'))
            {
                segmentCounts['e']++;
            }
            if (subStrings[loop].Contains('f'))
            {
                segmentCounts['f']++;
            }
            if (subStrings[loop].Contains('g'))
            {
                segmentCounts['g']++;
            }
        }


        //dealing with number to the right of the |
        if (loop >= 10)
        {
            int letterSum = 0;

            if (subStrings[loop].Contains('a'))
            {
                letterSum += segmentCounts['a'];
            }
            if (subStrings[loop].Contains('b'))
            {
                letterSum += segmentCounts['b'];
            }
            if (subStrings[loop].Contains('c'))
            {
                letterSum += segmentCounts['c'];
            }
            if (subStrings[loop].Contains('d'))
            {
                letterSum += segmentCounts['d'];
            }
            if (subStrings[loop].Contains('e'))
            {
                letterSum += segmentCounts['e'];
            }
            if (subStrings[loop].Contains('f'))
            {
                letterSum += segmentCounts['f'];
            }
            if (subStrings[loop].Contains('g'))
            {
                letterSum += segmentCounts['g'];
            }

            if (loop == 10)
            {
                digit[0] = returnDigit(letterSum);
            }
            else if (loop == 11)
            {
                digit[1] = returnDigit(letterSum);
            }
            else if (loop == 12)
            {
                digit[2] = returnDigit(letterSum);
            }
            else if (loop == 13)
            {
                digit[3] = returnDigit(letterSum);
            }

        }

    }

    totalSum += (digit[0] * 1000 + digit[1] * 100 + digit[2] * 10 + digit[3]);

}

//answer is 1016804

Console.WriteLine("The total sum is " + totalSum + ".");

watch.Stop();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

Console.WriteLine("");
Console.WriteLine("Press any key to continue.");
Console.ReadKey();



static int returnDigit(int count)
{
    switch (count)
    {
        case 42:
            return 0;
        case 17:
            return 1;
        case 34:
            return 2;
        case 39:
            return 3;
        case 30:
            return 4;
        case 37:
            return 5;
        case 41:
            return 6;
        case 25:
            return 7;
        case 49:
            return 8;
        case 45:
            return 9;
        default:
            throw new Exception("Well crap. The count that caused the error is " + count);
            //return 10; //this is a fail
    }
}